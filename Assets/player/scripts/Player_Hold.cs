using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hold : MonoBehaviour
{
    public GameObject heldObject;
    private Rigidbody heldcol;
    public thirdPersonMovement movement;
    public GameObject holdpoint;
    public GameObject putPoint;
    public Animator animator;
    private bool isHolding;

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
            
        }
    }
    private void Update()
    {

    }
}
