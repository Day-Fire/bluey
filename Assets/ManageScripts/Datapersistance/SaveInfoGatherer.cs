using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class SaveInfoGatherer : MonoBehaviour
{
    private GameData data;

    public TextMeshProUGUI savename;
    public TextMeshProUGUI saveSlot;
    public TextMeshProUGUI Time;
    public TextMeshProUGUI Place;
    public TextMeshProUGUI lastSave;

    private int min;
    private int hours;
    private int days;
    private int timeleft;
    public string[] names;

    public void fileChosen(int place)
    {
        data = DataManager.gamedata;
        savename.text = data.Name;
        saveSlot.text = "SAVE " + (place + 1);

        timeleft = data.TotalTime;
        hours = timeleft / 60;
        days = hours / 24;
        hours = hours % 24;
        min = timeleft % 60;
        
        string timetext = "TIME: ";
        if(days < 9)
        {
            timetext += "0" + days;
        }
        else
        {
            timetext += days;
        }
        timetext += ":";
        if (hours < 9)
        {
            timetext += "0" + hours;
        }
        else
        {
            timetext += hours;
        }
        timetext += ":";
        if (min < 9)
        {
            timetext += "0" + min;
        }
        else
        {
            timetext += min;
        }
        Time.text = timetext;
        Place.text = names[data.savespot];
        lastSave.text = "Last Save: \n"+data.LastSave.Substring(0,18);
    }
}
