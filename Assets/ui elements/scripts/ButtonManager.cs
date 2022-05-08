using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Transform btn;
    public Transform trgt;
    public Vector3 velocity;
    public float damping;
    public float speed;
    public bool isActive;
    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            velocity += (trgt.position - btn.position) / speed;
            velocity = Vector3.Lerp(velocity, Vector3.zero, damping);
            btn.position += velocity * Time.deltaTime;
        }
    }
}
