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
    public GameObject truePutPoint;
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
        playercontrols.normal.Action.started += _ => setDownStart(heldcol);
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
    public void setDownStart(Rigidbody objectCol)
    {
        bool empty = false;

        //Collider[] placeCheck = Physics.OverlapBox(putPoint.transform.position, objectCol.bounds.extents+new Vector3(0.2f, 0.2f, 0.2f), objectCol.transform.rotation);
        //empty = (placeCheck.Length == 0);
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
            //placeCheck = Physics.OverlapBox(putPoint.transform.position, objectCol..bounds.extents*2, Quaternion.LookRotation(hit.normal));
            //empty = (placeCheck.Length == 0);

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
        if (heldObject != null)
        {
            Transform truePutPoint = null; 
            heldObject.GetComponent<FollowPoint>().pointToFollow = truePutPoint;
            heldObject.GetComponent<FollowPoint>().snap();
            heldObject.GetComponent<FollowPoint>().pointToFollow = null;
        }
        heldObject = null;
    }
    public void pickUp(GameObject obj)
    {
        if (!isHolding)
        {
            isHolding = true;
            heldObject = obj;
            animator.SetTrigger("pickup");  
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
