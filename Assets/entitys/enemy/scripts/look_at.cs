using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_at : MonoBehaviour
{
    public Transform target;
    private Vector3 lerptarget;
    private Quaternion targetRotation;

    void Update()
    {
        lerptarget = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
        targetRotation = Quaternion.LookRotation(-lerptarget, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
    }
}
