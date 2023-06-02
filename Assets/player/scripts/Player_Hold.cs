using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hold : MonoBehaviour
{
<<<<<<< Updated upstream
    public GameObject heldObject;
    Rigidbody heldcol;
    public thirdPersonMovement movement;
    public GameObject holdpoint;
    public GameObject putPoint;
    private PlayerControls playercontrols;
=======

    private GameObject heldobj;
    public thirdPersonMovement movement;
    public GameObject holdpoint;
    public GameObject putPoint;
    public GameObject truePutPoint;
>>>>>>> Stashed changes
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
            //movement.canroll = false;
            heldObject.transform.position = holdpoint.transform.position;
            heldObject.transform.rotation = holdpoint.transform.rotation;
        }
        else
        {
            //movement.canroll = true;
        }
    }
    public GameObject getPutPoint()
    {
        return putPoint;
    }
    public void setDownStart(Collider objectCol)
    {
        bool empty = false;

        Collider[] placeCheck = Physics.OverlapBox(putPoint.transform.position, objectCol.bounds.extents+new Vector3(0.2f, 0.2f, 0.2f), objectCol.transform.rotation);
        empty = (placeCheck.Length == 0);
        RaycastHit hit;
        Physics.Raycast(transform.position, transform.forward, out hit, 1f);
        if (empty)
        {
            animator.SetTrigger("putdown");
            truePutPoint.transform.position = putPoint.transform.position;
            truePutPoint.transform.rotation = putPoint.transform.rotation;
            gameObject.GetComponent<playerinteraction>().InteractionHold = false;
        }
        else
        {
            placeCheck = Physics.OverlapBox(putPoint.transform.position, objectCol.bounds.extents*2, Quaternion.LookRotation(hit.normal));
            empty = (placeCheck.Length == 0);

            if (empty)
            {
                animator.SetTrigger("putdown");
                truePutPoint.transform.position = putPoint.transform.position;
                truePutPoint.transform.rotation = Quaternion.LookRotation(hit.normal);
                gameObject.GetComponent<playerinteraction>().InteractionHold = false;
            }
        }
    }
    public void setDownEnd()
    {
        isHolding = false;
        if (heldobj != null)
        {
            Transform truePutPoint = null; 
            heldobj.GetComponent<FollowPoint>().pointToFollow = truePutPoint;
            heldobj.GetComponent<FollowPoint>().snap();
            heldobj.GetComponent<FollowPoint>().pointToFollow = null;
        }
        heldobj = null;
    }
    public void pickUp(GameObject obj)
    {
        if (!isHolding)
        {
            isHolding = true;
<<<<<<< Updated upstream
            animator.SetTrigger("pickup");
            movement.maxspeed = 3;
            heldObject = obj;
            heldcol = obj.GetComponent<Rigidbody>();
            heldcol.useGravity = false;
=======
            heldobj = obj;
            animator.SetTrigger("pickup");  
>>>>>>> Stashed changes
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
