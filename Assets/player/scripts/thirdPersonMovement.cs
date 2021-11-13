using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonMovement : MonoBehaviour
{
    private PlayerControls playercontrols;

    public Transform cam;
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
    public bool canroll = true;
    public float grounddistance = 0.4f;
    public LayerMask groundMask;
    public bool isgrounded = false;
    Vector3 movedir;
    public Vector3 additionalforces;
    float turnsmoothvel;
    Vector3 oldEulerAngles;
    bool isSpining = false;
    float spintime = 0f;
    public float knockbackforce;
    public float knockbacktime;
    private float knockbacktaken;

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
        playercontrols.normal.roll.performed += _ => roll();
    }
    
    private void roll()
    {
        if (canroll)
        {
            animator.SetTrigger("roll");
        }
    }

    private void midroll()
    {
        speedadd = 20;
    }

    // Update is called once per frame
    void Update()
    {
        isgrounded = Physics.CheckBox(groundpoint.position, groundpoint.lossyScale/2, groundpoint.rotation, groundMask);
        animator.SetFloat("speed",speed);
        animator.SetBool("spinn",isSpining);
        Vector2 playerinput = playercontrols.normal.move.ReadValue<Vector2>();
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
            float targetangle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvel, turnsmoothtime);
            transform.rotation = Quaternion.Euler(0f,angle, 0f);
            movedir = Quaternion.Euler(0f, targetangle, 0f) * Vector3.left;
            controller.Move(movedir * (speed+speedadd) * Time.deltaTime);
        }
        else if (speed >= 0.1 || speedadd >= 0.1)
        {
            speed -= velocity;
            speed = Mathf.Clamp(speed, minspeed, maxspeed);
            controller.Move(movedir * (speed + speedadd) * Time.deltaTime);
            speedadd -= velocity/2;
            speedadd = Mathf.Clamp(speedadd, 0, 20);
        }
        controller.Move(new Vector3(movedir.x * additionalforces.x,movedir.y, movedir.z * additionalforces.z) * Time.deltaTime);

        if (Mathf.Abs(oldEulerAngles.y - gameObject.transform.rotation.eulerAngles.y) > 15)
        {
            spintime += 0.5f * Time.deltaTime;
        }
        if (Mathf.Abs(oldEulerAngles.y - gameObject.transform.rotation.eulerAngles.y) < 7)
        {
            isSpining = false;
        }
        if (spintime > 1f)
        {
            spintime = 0;
            isSpining = true;
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
    public void knockback()
    {
        knockbacktaken = knockbacktime;
    }
}
