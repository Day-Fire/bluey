using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthAssign : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    [SerializeField]
    private RawImage[] hearts;

    public Texture fullHeart;
    public Texture emptyHeart;

    public void setHealth(int health)
    {
        this.health = health;
    }
    void Update()
    {
        health = Mathf.Min(health, numOfHearts);
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].texture = fullHeart;
            } else
            {
                hearts[i].texture = emptyHeart;
            }
            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }
}
