using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class TitleManager : MonoBehaviour
{
    public Transform startbtn;
    public Transform starttrgt;
    public Vector3 velocity;
    public float maxSpeed;
    public void pressStart()
    {
        Debug.Log("let's a go");
    }

    private void Update()
    {
        velocity += (starttrgt.position - startbtn.position) / 2;
        velocity = Vector3.Lerp(velocity, Vector3.zero, 0.05f);
        startbtn.position += velocity * Time.deltaTime;
        
    }
}
