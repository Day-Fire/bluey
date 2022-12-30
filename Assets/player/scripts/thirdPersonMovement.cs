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
    public enum PlayerState
    {
        idle,
        walk,
        run,
        spin,
        sled,
        roll,
    }
    [Space(10)]
    [SerializeField]
    private PlayerState state = PlayerState.idle;
    private PlayerState prevstate = PlayerState.idle;
    [SerializeField]
    private bool canChangeState = true;
    // Create a new dictionary of strings, with string keys.
    //
    Dictionary<PlayerState,PlayerState[]> stateTransistions = new Dictionary<PlayerState, PlayerState[]>();
    [Space(10)]
    public float speed = 10f;
    public float velocity = 1.5f;
    public float fallvel = 0f;
    public float gravity = -9.81f;
    public float maxspeed = 50f;
    public float minspeed = 0f;

    public float turnsmoothtime = 0.1f;
    public float grounddistance = 0.4f;
    Vector3 oldEulerAngles;
    float turnsmoothvel;

    Vector3 movedir;
    public Vector3 additionalforces;

    public LayerMask groundMask;
    public bool isgrounded = false;
    [Space(10)]
    Vector3 rolldir;
    public float rollspeed;
    [Space(10)]
    float spintime = 0f;
    Queue<float> spinamt = new Queue<float>();
    Vector3 prevdir;
    [Space(10)]
    public float sledSpeed = 0f;
    public float sledStartSpeed = 16f;
    public Transform gfx;
    public float slopeAceMod;
    public float slopeFriction;

    public Transform sledRaycast;
    public float sledRayDist;
    public ParticleSystem wind;
    
    private void Awake()
    {
        playercontrols = gameObject.GetComponent<PlayerInput>();

        PlayerState[] temp = { PlayerState.idle, PlayerState.roll, PlayerState.sled, PlayerState.spin, PlayerState.run };
        stateTransistions.Add(PlayerState.walk, temp);

        PlayerState[] temp2 = { PlayerState.walk, PlayerState.roll, PlayerState.sled };
        stateTransistions.Add(PlayerState.idle, temp2);

        PlayerState[] temp3 = { PlayerState.idle };

        stateTransistions.Add(PlayerState.spin, temp3);

        PlayerState[] temp4 = { PlayerState.idle, PlayerState.run };

        stateTransistions.Add(PlayerState.sled, temp4);

        stateTransistions.Add(PlayerState.run, temp4);

        stateTransistions.Add(PlayerState.roll, temp4);
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void roll()
    {
        //Debug.Log("state:" + state);
        if (state != PlayerState.roll)
        {
            animator.SetTrigger("rollTrg");
        }
        changeState(PlayerState.roll);
        canChangeState = false;
        rolldir = get_input();
        //Debug.Log("Roolll!");
    }

    private void endroll()
    {
        canChangeState = true;
        changeState(PlayerState.idle);
    }

    private void endSled()
    {
        sledSpeed = 3;
        Fov.resetFov();
        wind.Stop();
        canChangeState = true;
        Debug.Log(changeState(PlayerState.idle));
    }

    // Update is called once per frame
    void Update()
    {
        //check if player is on the ground
        check_ground();

        //interface with the animator and set varibles/play animations
        animator.SetFloat("speed",speed);
        animator.SetFloat("sledspeed", sledSpeed);
        if(state == PlayerState.spin)
        {
            animator.SetBool("spin", true);
        }
        else
        {
            animator.SetBool("spin", false);
        }

        //set player rotated to the ground
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, 2f, groundMask);
        gfx.rotation = Quaternion.Lerp(gfx.rotation, Quaternion.FromToRotation(gfx.up, hit.normal) * gfx.rotation, 0.2f);

        //get player input direction for walking/running
        Vector3 dir = get_input();

        //Debug.Log(state + " current state");

        //seting the playerstate
        if (dir.magnitude >= 0.1)
        {
            changeState(PlayerState.walk);
        }
        else
        {
            changeState(PlayerState.idle);
        }

        if (check_spin(dir))
        {
            changeState(PlayerState.spin);
        }

        //gravity 
        preform_Gravity();

        switch (state)
        {
            case PlayerState.walk:
                preform_walk(dir);
                break;
            case PlayerState.idle:
                preform_idle();
                break;
            case PlayerState.roll:
                preform_roll();
                break;
            case PlayerState.sled:
                preform_sled(dir);
                break;
            case PlayerState.spin:
                preform_spin();
                break;
        }

        prevstate = state;
    }

    public bool changeState(PlayerState newState )
    {
        bool changed = false;
        if (canChangeState)
        {
            PlayerState[] found;
            if (stateTransistions.TryGetValue(state, out found))
            {
                foreach (PlayerState x in found)
                {
                    if (x == newState)
                    {
                        changed = true;
                        state = newState;
                    }
                }
            }
        }
        if (changed)
        {
            //Debug.Log("playerstate was changed");
            return true;
        }
        else
        {
            return false;
            //Debug.Log("playerstate unchanged");
        }
    }

    public bool hardSetState(PlayerState newState)
    {
        bool changed = false;
        if (canChangeState)
        {
            PlayerState[] found;
            if (stateTransistions.TryGetValue(state, out found))
            {
                foreach (PlayerState x in found)
                {
                    if (x == newState)
                    {
                        changed = true;
                        state = newState;
                    }
                }
            }
        }
        if (changed)
        {
            //Debug.Log("playerstate was changed");
            canChangeState = false;
            return true;
        }
        else
        {
            return false;
            //Debug.Log("playerstate unchanged");
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

    private void preform_walk(Vector3 dir)
    {
        speed += velocity;
        speed = Mathf.Clamp(speed, minspeed, maxspeed);
        float targetangle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvel, turnsmoothtime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.left;

        controller.Move(movedir * (speed) * Time.deltaTime);
    }

    private void preform_idle()
    {
        speed -= velocity;
        speed = Mathf.Clamp(speed, minspeed, maxspeed);
        controller.Move(movedir * (speed) * Time.deltaTime);
    }

    private void preform_roll()
    {
        if(rolldir == new Vector3(0,0,0))
        {
            Debug.Log("ioiff");
            rolldir = new Vector3(1,0,0);
        }
        float targetangle = Mathf.Atan2(rolldir.x, rolldir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvel, turnsmoothtime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.left;
        controller.Move(movedir * (rollspeed) * Time.deltaTime);
    }

    private void preform_spin()
    {
        
    }

    private void preform_sled(Vector3 dir)
    {
        //get slope data
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit, float.MaxValue, groundMask);

        float slopeAngle = Vector3.Angle(transform.forward, hit.normal) - 90;

        if (sledSpeed >= 10)
        {
            sledSpeed += ((slopeAngle * slopeAceMod) - slopeFriction) * Time.deltaTime;
        }
        else
        {
            sledSpeed += ((slopeAngle * slopeAceMod) - slopeFriction/3) * Time.deltaTime;
        }
        //move according to sledspeed
        float targetangle = Mathf.Atan2(1, dir.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvel, turnsmoothtime);

        transform.rotation = Quaternion.Euler(0f, angle, 0f);
        movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.left;

        controller.Move(Vector3.ProjectOnPlane(movedir, hit.normal) * (sledSpeed) * Time.deltaTime);

        if (sledSpeed > 40f)
        {
            wind.Play();
            Fov.changeFov(15);
        } 
        else if (sledSpeed < 15f)
        {
            Fov.changeFov(-8);
        }
        else
        {
            Fov.resetFov();
            wind.Stop();
        }
        if (sledSpeed <= 0)
        {
            animator.SetBool("sledend", true);
            sledSpeed = sledStartSpeed;
        }
    }

    private Vector3 get_input()
    {
        Vector2 playerinput;
        playerinput = playercontrols.actions["move"].ReadValue<Vector2>();
        return new Vector3(playerinput.y, 0, -playerinput.x);
    }
    private bool check_spin(Vector3 dir)
    {
        //Debug.Log(Mathf.Floor(Vector3.Angle(dir.normalized, prevdir.normalized)));
        if(Mathf.Floor(Vector3.Angle(dir.normalized, prevdir.normalized)) > 0)
        {
            spintime += 2 * Time.deltaTime;
        }
        else if (Mathf.Floor(Vector3.Angle(dir.normalized, prevdir.normalized)) > 90 || Mathf.Floor(Vector3.Angle(dir.normalized, prevdir.normalized)) < 0)
        {
            spintime = 0;
        }
        else
        {
            spintime -= 0.5f * Time.deltaTime;
        }

        prevdir = dir;
        spintime = Mathf.Clamp(spintime, 0, 1.2f);
        if (spintime >= 0.8f)
        {
            return true;
        }

        return false;
    }
}
