using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_stats : MonoBehaviour
{
    //input--
    private PlayerControls playercontrols;

    private void Awake()
    {
        playercontrols = new PlayerControls();
    }

    private void OnEnable()
    {
        playercontrols.Enable();
    }

    private void OnDisable()
    {
        playercontrols.Disable();
    }
    private void Start()
    {
        playercontrols.normal.item_use.performed += ctx => useItem(ctx.control.layout, 0);
    }

    //Health---
    [SerializeField]
    private int health = 3;
    public healthAssign healthbar;

    //Items---
    [SerializeField]
    private Item[] items;

    public Item topEquip;
    public Item midEquip;
    public Item btmEquip;

    public RawImage topImage;
    public RawImage midImage;
    public RawImage btmImage;

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

        topImage.texture = topEquip.icon;
        midImage.texture = midEquip.icon;
        btmImage.texture = btmEquip.icon;
    }
    void useItem(string cont, int index)
    {
        //lil note context is equal to button if pressed by a controller and key if on a keyboard (;
        if (cont == "Button")
        {
            switch (index)
            {
                case 0:
                    topEquip.use();
                    break;
                case 1:
                    midEquip.use();
                    break;
                case 2:
                    btmEquip.use();
                    break;
            }
        }
        else if(cont == "Key")
        { 
            
        }
        else
        {
            Debug.Log(cont + " is not supported yet ):");
        }
    }
}
