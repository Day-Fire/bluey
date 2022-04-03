using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollTexture : MonoBehaviour
{
    private Material mat;
    public float xspeed;
    public float yspeed;
    private float x;
    private float y;


    // Update is called once per frame
    void Update()
    {
        x += xspeed * Time.deltaTime;
        y += yspeed * Time.deltaTime;
        gameObject.GetComponent<Renderer>().material.mainTextureOffset = new Vector2( x, y);
    }
}
