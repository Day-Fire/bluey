using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveDataGatherer : MonoBehaviour
{
    public int saveslot;
    private GameData data;
    public SaveInfoGatherer info;

    public TextMeshProUGUI savename;
    void Start()
    {
        data = DataManager.gameDatums[saveslot];
        savename.text = data.Name;
    }

    public void selectslot()
    {
        DataManager.selectData(saveslot);
        info.fileChosen(saveslot);
    }
}
