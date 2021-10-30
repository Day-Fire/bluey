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
    // Update is called once per frame
    void Update()
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
    public void setDown()
    {
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
        movement.maxspeed /= 2;
        heldObject = obj;
        heldcol = obj.GetComponent<Rigidbody>();
        heldcol.useGravity = false;
    }
}
