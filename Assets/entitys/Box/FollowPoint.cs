using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPoint : MonoBehaviour
{
    public Transform pointToFollow;
    public bool willLerp;
    public float lerpAmt;
    public bool Rotation;

    // Update is called once per frame
    void Update()
    {
        if (pointToFollow != null)
        {
            this.transform.position = pointToFollow.position;
            if (Rotation)
            {
                this.transform.rotation = pointToFollow.rotation;
            }
        }
    }
}
