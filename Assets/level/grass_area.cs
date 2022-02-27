using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grass_area : MonoBehaviour
{

    public GameObject grass;
    public BoxCollider col;
    public int amount;
    public LayerMask layerMask;
    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-(col.size.x / 2), col.size.x / 2), 0, Random.Range(-(col.size.z / 2), col.size.z / 2));
            RaycastHit hit;
            if (Physics.Raycast(transform.position + position, Vector3.down, out hit, Mathf.Infinity, layerMask))
            {
                Instantiate(grass, hit.point, Quaternion.EulerAngles(hit.normal));
            }
        }
    }
}
