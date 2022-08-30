using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour
{
    private GameData gameData;

    public static DataPersistanceManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Tried to make more than one Data Persistance Manager.");
        }
            
        instance = this;
    }

    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void LoadGame()
    {
        //todo

        if (this.gameData == null)
        {
            Debug.Log("No data was found. Initializing defaults");
            NewGame();
        }
    }

    public void SaveGame()
    {
         
    }
}
