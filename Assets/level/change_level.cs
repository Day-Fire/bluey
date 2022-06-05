using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_level : MonoBehaviour
{
    public Transform playerspawn;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("entered");
        // Debug.Log(other.gameObject.name);
        if (other.gameObject.name == "player")
        {
            Transform playertransform = other.GetComponent<Transform>();
            thirdPersonMovement movement = other.GetComponent<thirdPersonMovement>();
            //movement.canWalk = false;
            playertransform.position = playerspawn.position;
            playertransform.rotation = playerspawn.rotation;
            Physics.SyncTransforms();
            //Debug.Log("player: " + playertransform.position);
            //Debug.Log("expect: " + playerspawn.position);
        }
    }
}
