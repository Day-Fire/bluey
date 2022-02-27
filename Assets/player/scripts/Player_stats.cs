using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player_stats : MonoBehaviour
{
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
}
