using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveEmissions : MonoBehaviour
{
    private Color Orig;
    public float speed;
    public float amp;
    public float offset;
    private float intencity;


    private void Start()
    {
        Orig = gameObject.GetComponent<Renderer>().material.GetColor("_EmissionColor");
    }

    // Update is called once per frame
    void Update()
    {
        intencity = Mathf.Sin(Time.realtimeSinceStartup * speed) * amp + offset;

        Color newColor = new Color(Mathf.Max(Orig.r * intencity, Orig.r), Mathf.Max(Orig.g * intencity, Orig.g), Mathf.Max(Orig.b * intencity, Orig.b));
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", newColor);
    }
}
