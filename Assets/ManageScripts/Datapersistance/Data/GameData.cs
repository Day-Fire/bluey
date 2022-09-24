using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class GameData
{
    public string Name;
    public int TotalTime;
    public int health;
    public int savespot;
    public string LastSave;


    public GameData()
    {
        this.Name = "-- New --";
        this.TotalTime = 0;
        this.health = 3;
        this.LastSave = System.DateTime.Now.ToString();

    }   
}
