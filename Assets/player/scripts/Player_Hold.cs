using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hold : MonoBehaviour
{
    public GameObject heldObject;
    Rigidbody heldcol;
    public thirdPersonMovement movement;
    public GameObject holdpoint;
    public GameObject putPoint;
    private PlayerControls playercontrols;
    public Animator animator;
    private bool isHolding;

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
        playercontrols.normal.Action.started += _ => setDownStart();
    }


    // Update is called once per frame
    void LateUpdate()
    {
        if (heldObject != null)
        {
            movement.canroll = false;
            heldObject.transform.position = holdpoint.transform.position;
            heldObject.transform.rotation = holdpoint.transform.rotation;
        }
        else
        {
            movement.canroll = true;
        }
    }
    public GameObject getPutPoint()
    {
        return putPoint;
    }
    public void setDownStart()
    {
        if (heldObject != null) {
            Collider collider = heldObject.GetComponent<BoxCollider>();
            Collider[] colliderar = Physics.OverlapBox(putPoint.transform.position, collider.bounds.extents, putPoint.transform.rotation);
            bool empty = true;
            for (int i = 0; i < colliderar.Length; i++)
            {
                    if (colliderar[i].gameObject.layer == 7)
                    {
                        empty = false;
                    }
            }
            if (empty) {
                animator.SetTrigger("putdown");
            }
        }
    }
    public void setDownEnd()
    {
        isHolding = false;
        movement.maxspeed = 0f;
        movement.speed = 0;
        heldObject.transform.position = putPoint.transform.position;
        heldObject.transform.rotation = putPoint.transform.rotation;
        heldcol.useGravity = true;
        movement.maxspeed = 12f;
        heldObject = null;
    }
    public void pickUp(GameObject obj)
    {
        if (!isHolding)
        {
            isHolding = true;
            animator.SetTrigger("pickup");
            movement.maxspeed = 3;
            heldObject = obj;
            heldcol = obj.GetComponent<Rigidbody>();
            heldcol.useGravity = false;
        }
    }
    private void Update()
    {
        if (isHolding)
        {
            movement.speed = Mathf.Min(movement.speed, 5);
        }
    }
}
