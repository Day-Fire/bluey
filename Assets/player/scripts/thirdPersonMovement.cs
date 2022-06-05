using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class thirdPersonMovement : MonoBehaviour
{
    private PlayerControls playercontrols;

    public Transform camTrnsfm;
    public CinemachineFovEditor Fov;
    public Transform groundpoint;
    public CharacterController controller;
    public Animator animator;

    public float speed = 6f;
    public float velocity = 1.5f;
    public float fallvel = 0f;
    public float gravity = -9.81f;
    public float maxspeed = 12f;
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

    bool isSpining = false;
    float spintime = 0f;

    public bool canroll = true;
    public bool canWalk = true;

    public bool isSleding = false;
    public float sledSpeed = 16f;
    public float sledSpeedMax = 20f;

    public Transform sledRaycast;
    public float sledRayDist;
    public ParticleSystem wind;

    private void Awake()
    {
        playercontrols = new PlayerControls();
    }

    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    public void roll()
    {
        if (canroll && canWalk && !isSleding)
        {
            Debug.Log("lol: " + canroll + " :" + canWalk);
            animator.SetTrigger("roll");
            canroll = false;
        }
    }

    private void midroll()
    {
        speedadd += 20;
    }

    private void endroll()
    {
        //canroll = true;
    }

    private void endSled()
    {
        animator.SetBool("sledend",false);
        canroll = true;
        isSleding = false;
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckBox(groundpoint.position, groundpoint.lossyScale/2, groundpoint.rotation, groundMask);
        animator.SetFloat("speed",speed);
        animator.SetBool("spinn",isSpining);
        Vector2 playerinput;
        if (canWalk)
        {
            playerinput = playercontrols.normal.move.ReadValue<Vector2>();
        }
        else
        {
            playerinput = Vector2.zero;
        }
        Vector3 dir = new Vector3(playerinput.y, 0, -playerinput.x);

        if(isgrounded && fallvel != -5)
        {
            fallvel = -5f;
        }

        fallvel += gravity * Time.deltaTime;
        controller.Move(new Vector3(0,fallvel* Time.deltaTime,0));

        if (dir.magnitude >= 0.1)
        {
            speed += velocity;
            speed = Mathf.Clamp(speed, minspeed, maxspeed);
            speedadd -= velocity;
            speedadd = Mathf.Clamp(speedadd, 0, 20);
            float targetangle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + camTrnsfm.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvel, turnsmoothtime);
            transform.rotation = Quaternion.Euler(0f,angle, 0f);
            movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.left;
            if (!isSleding)
            {
                controller.Move(movedir * (speed + speedadd) * Time.deltaTime);
            }
        }
        else if (speed >= 0.1 || speedadd >= 0.1)
        {
            speed -= velocity;
            speed = Mathf.Clamp(speed, minspeed, maxspeed);
            if (!isSleding)
            {
                controller.Move(movedir * (speed + speedadd) * Time.deltaTime);
            }
            speedadd -= velocity/2;
            speedadd = Mathf.Clamp(speedadd, 0, 20);
        }
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

        if (Mathf.Abs(oldEulerAngles.y - gameObject.transform.rotation.eulerAngles.y) > 15)
        {
            spintime += 0.5f * Time.deltaTime;
        }
        if (Mathf.Abs(oldEulerAngles.y - gameObject.transform.rotation.eulerAngles.y) < 7)
        {
            isSpining = false;
            canroll = true;
        }
        if (spintime > 1f)
        {
            spintime = 0;
            isSpining = true;
            canroll = false;
        }
        oldEulerAngles = gameObject.transform.rotation.eulerAngles;
        if (isSpining)
        {
            maxspeed /= 5;
        }
        else
        {
            maxspeed = 12;
        }
    }
}
