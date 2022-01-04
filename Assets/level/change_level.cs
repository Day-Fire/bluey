using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class change_level : MonoBehaviour
{
    public Transform playerspawn;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        Debug.Log(other.gameObject.name);
        Transform playertransform = other.gameObject.GetComponent<Transform>();
        playertransform = playerspawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
