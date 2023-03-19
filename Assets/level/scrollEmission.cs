using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollEmission : MonoBehaviour
{
    public Color emissiveColor;
    public float originalEmission;
    public float inensity;
    public float time;
    private float emissiveIntensity;


    // Update is called once per frame
    void Update()
    {
        emissiveIntensity = originalEmission + Mathf.Sin(Time.realtimeSinceStartup * time) * inensity;
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissiveColor", emissiveColor * emissiveIntensity);
    }
}
