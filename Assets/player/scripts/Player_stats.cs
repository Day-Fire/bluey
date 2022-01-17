using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_stats : MonoBehaviour
{
    [SerializeField]
    private int health = 3;
    public float itime = 1f;
    private float curitime = 0f;
    public healthbar healthbar;
    public thirdPersonMovement movement;

    [SerializeField]
    private bool[] items;

    [SerializeField]
    private Item[] keyitems;
    public Item curitem;
    

    public void hurt(int damage)
    {
        if (curitime == 0)
        {
            Debug.Log("oow");
            health -= damage;
            curitime = itime;
        }
        health = Mathf.Max(0, health);
    }

    // Update is called once per frame
    void Update()
    {
        curitime -= 1 * Time.deltaTime;
        curitime = Mathf.Max(0,curitime);
        healthbar.SetHealth(health);
    }
}
