using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonMovement : MonoBehaviour
{
    private PlayerControls playercontrols;

    public Transform cam;
    public CharacterController controller;
    public Animator animator;
    public float speed = 6f;
    public float velocity = 1.5f;
    public float maxspeed = 12f;
    public float minspeed = 0f;
    public float speedadd = 0f;
    public float turnsmoothtime = 0.1f;
    public bool canroll = true;
    Vector3 movedir;
    float turnsmoothvel;
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
        animator.SetFloat("speed",speed);
        Vector2 playerinput = playercontrols.normal.move.ReadValue<Vector2>();
        Vector3 dir = new Vector3(playerinput.y, 0, -playerinput.x);

        

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
    }
}
