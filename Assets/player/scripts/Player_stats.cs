using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
public class Player_stats : MonoBehaviour
{

    //Health---
    [SerializeField]
    private int health = 3;
    public healthAssign healthbar;

    //Items---
    [SerializeField]
    private Item[] items;

    public Item Equip;

    public RawImage Image;

    public double holdtime;
    public InputAction.CallbackContext startctx;
    public void hurt(int damage)
    {
        Debug.Log("oow");
        health -= damage;
        health = Mathf.Max(0, health);
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.setHealth(health);

        Image.texture = Equip.icon;
    }

    public void useItem(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            startctx = context;
        }
        Debug.Log("yes");
        if (context.canceled == true)
        {
            Debug.Log("im");
            Debug.Log(startctx.duration);
            if (startctx.duration < holdtime)
            {
                Equip.use();
                Debug.Log("stupid");
            }
        }
    }
}
