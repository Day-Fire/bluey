using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class thirdPersonMovement : MonoBehaviour
{
    public PlayerInput playercontrols;

    public Transform cameraTransform;
    public CinemachineFovEditor Fov;
    public Transform groundpoint;
    public CharacterController controller;
    public Animator animator;

    enum PlayerState
    {
        idle,
        walk,
        run,
        spin,
        sled,
        roll,
        stopped
    }
    [SerializeField]
    private PlayerState state = PlayerState.idle;
    // Create a new dictionary of strings, with string keys.
    //
    Dictionary<PlayerState,PlayerState[]> stateTransistions = new Dictionary<PlayerState, PlayerState[]>();

    public float speed = 10f;
    public float velocity = 1.5f;
    public float fallvel = 0f;
    public float gravity = -9.81f;
    public float maxspeed = 50f;
    public float minspeed = 0f;
    public float speedadd = 0f;

    public float turnsmoothtime = 0.1f;
    public float grounddistance = 0.4f;
    Vector3 oldEulerAngles;
    float turnsmoothvel;

    Vector3 movedir;
    public Vector3 additionalforces;

    public LayerMask groundMask;
    public bool isgrounded = false;

    float spintime = 0f;

    public float sledSpeed = 16f;
    public float sledSpeedMax = 20f;

    public Transform sledRaycast;
    public float sledRayDist;
    public ParticleSystem wind;

    private void Awake()
    {
        playercontrols = gameObject.GetComponent<PlayerInput>();

        PlayerState[] temp = { PlayerState.idle, PlayerState.roll, PlayerState.sled, PlayerState.stopped, PlayerState.spin, PlayerState.run };
        stateTransistions.Add(PlayerState.walk, temp);

        PlayerState[] temp2 = { PlayerState.walk, PlayerState.roll, PlayerState.sled, PlayerState.stopped };
        stateTransistions.Add(PlayerState.idle, temp2);

        PlayerState[] temp3 = { PlayerState.idle };
        stateTransistions.Add(PlayerState.stopped, temp3);

        stateTransistions.Add(PlayerState.spin, temp3);

        stateTransistions.Add(PlayerState.sled, temp3);

        PlayerState[] temp4 = { PlayerState.idle, PlayerState.run };
        stateTransistions.Add(PlayerState.run, temp4);

        stateTransistions.Add(PlayerState.roll, temp4);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void roll()
    {
        Debug.Log("state:" + state);
        if ((int)state < (int)PlayerState.sled)
        {
            state = PlayerState.roll;
            Debug.Log("Roolll!");
            animator.SetTrigger("roll");
        }
    }

    private void midroll()
    {
        speedadd += 20;
    }

    private void endroll()
    {
        state = PlayerState.idle;
    }

    private void endSled()
    {
        Debug.Log("Roolll!");
        animator.SetBool("sledend",false);
        state = PlayerState.idle;
    }

    // Update is called once per frame
    void Update()
    {
        //check if player is on the ground
        check_ground();

        //interface with the animator and set varibles/play animations
        animator.SetFloat("speed",speed);

        //get player input direction for walking/running
        Vector3 dir = get_input();

        //seting the playerstate
        
        if (dir.magnitude >= 0.1)
        {
            changeState(PlayerState.walk);
        }
        if (speed >= 0.1 || speedadd >= 0.1)
        {
            changeState(PlayerState.idle);
        }

        //gravity 
        preform_Gravity();

        switch (state)
        {
            case PlayerState.walk:
                preform_Walk(dir);
                break;
            case PlayerState.idle:
                preform_idle();
                break;
        }

        //sleding
        /*
        if (!isSleding) 
        {
            controller.Move(new Vector3(movedir.x * additionalforces.x, movedir.y, movedir.z * additionalforces.z) * Time.deltaTime);
        }
        else
        {
            controller.Move(movedir * (sledSpeed) * Time.deltaTime);
            RaycastHit hit;
            if (Physics.Raycast(sledRaycast.position, Vector3.down, out hit, sledRayDist))
            {
                //Debug.DrawLine(sledRaycast.position, sledRaycast.position + Vector3.down * sledRayDist, Color.cyan, 0, true);
                //Debug.Log("distance: "+ hit.distance);
                float t = Mathf.InverseLerp(0, sledRayDist, hit.distance);
                //Debug.Log("inverse lerp: "+ t);
                sledSpeed += Mathf.Lerp(-30, 30, t) * Time.deltaTime;
                //Debug.Log("change: "+Mathf.Lerp(-30, 30, t));
            }
            else if (Physics.Raycast(sledRaycast.position, Vector3.down, out hit))
            {
                sledSpeed += 15;
            }
            else
            {
                sledSpeed -= 15;
            }
            sledSpeed = Mathf.Max(0, sledSpeed);
            sledSpeed = Mathf.Min(sledSpeed, sledSpeedMax);
            if(sledSpeed > 25f)
            {
                wind.Play();
                Fov.changeFov(15);
            }
            else
            {
                Fov.resetFov();
                wind.Stop();
            }
            if (sledSpeed <= 0)
            {
                animator.SetBool("sledend",true);
            }
        }
        */
        //spining
        
        oldEulerAngles = gameObject.transform.rotation.eulerAngles;
        if (check_spin())
        {
            animator.SetBool("spinn", true);
            maxspeed /= 5;
        }
        else
        {
            animator.SetBool("spinn", false);
            maxspeed = 12;
        }
    }

    private void changeState(PlayerState newState )
    {
        PlayerState[] found;
        bool changed = false;
        if (stateTransistions.TryGetValue(state, out found))
        {
            foreach(PlayerState x in found)
            {
                if(x == newState)
                {
                    changed = true;
                    state = newState;
                }
            }
        }
        if (changed)
        {
            Debug.Log("playerstate was changed");
        }
        else
        {
            Debug.Log("playerstate unchanged");
        }
    }

    private void check_ground()
    {
        isgrounded = Physics.CheckBox(groundpoint.position, groundpoint.lossyScale / 2, groundpoint.rotation, groundMask);
    }

    private void preform_Gravity()
    {
        //snaps player to ground 
        if (isgrounded && fallvel != -5)
        {
            fallvel = -5f;
        }

        // gravity when not on ground
        fallvel += gravity * Time.deltaTime;
        controller.Move(new Vector3(0, fallvel * Time.deltaTime, 0));
    }

    private void preform_Walk(Vector3 dir)
    {
        speed += velocity;
        speed = Mathf.Clamp(speed, minspeed, maxspeed);
        speedadd -= velocity;
        speedadd = Mathf.Clamp(speedadd, 0, 20);
        float targetangle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvel, turnsmoothtime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.left;

        controller.Move(movedir * (speed + speedadd) * Time.deltaTime);
    }

    private void preform_idle()
    {
        speed -= velocity;
        speed = Mathf.Clamp(speed, minspeed, maxspeed);
        controller.Move(movedir * (speed + speedadd) * Time.deltaTime);
        speedadd -= velocity / 2;
        speedadd = Mathf.Clamp(speedadd, 0, 20);
    }

    private Vector3 get_input()
    {
        Vector2 playerinput;
        playerinput = playercontrols.actions["move"].ReadValue<Vector2>();
        return new Vector3(playerinput.y, 0, -playerinput.x);
    }
    private bool check_spin()
    {
        if (Mathf.Abs(oldEulerAngles.y - gameObject.transform.rotation.eulerAngles.y) > 15)
        {
            spintime += 0.5f * Time.deltaTime;
        }
        if (Mathf.Abs(oldEulerAngles.y - gameObject.transform.rotation.eulerAngles.y) < 7)
        {
            return false;
        }
        if (spintime > 1f)
        {
            spintime = 0;
            return true;
        }
        return false;
    }
}
