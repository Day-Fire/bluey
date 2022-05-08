using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollSkybox : MonoBehaviour
{
    public Camera cam;
    public float xspeed;
    public float zspeed;
    public float yspeed;
    private float x;
    private float y;
    private float z;

    // Update is called once per frame
    void Update()
    {
        x += xspeed * Time.deltaTime;
        y += yspeed * Time.deltaTime;
        z += zspeed * Time.deltaTime;
        cam.transform.Rotate(new Vector3(xspeed,yspeed,zspeed));
    }
}
