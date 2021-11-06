using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage_touch : MonoBehaviour
{
    int damageontouch = 1;
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            Player_stats stats = col.gameObject.GetComponent<Player_stats>();
            stats.hurt(damageontouch);
        }
    }
}
