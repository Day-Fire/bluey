using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private string folderpath;
    public static GameData[] gameDatums = new GameData[3];
    public static GameData gamedata;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        folderpath = Application.persistentDataPath + "/saveData";
        Debug.Log(Application.persistentDataPath + "/saveData");
        for (int i = 0; i < 3; i++)
        {
            GameData data = DataLoader.load(folderpath, i);
            if(data != null)
            {
                gameDatums[i] = data;
            }
            else
            {
                gameDatums[i] = new GameData();
                DataLoader.save(folderpath,i,new GameData());
            }
        }

    }

    public bool saveData(int slot)
    {
        DataLoader.save(folderpath, slot, gamedata);
        return true;
    }

    public static void selectData(int slot)
    {
        gamedata = gameDatums[slot];
    }

}
