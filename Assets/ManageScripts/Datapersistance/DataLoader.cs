using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class DataLoader
{

    public static void save(string path, int saveslot, GameData gameData)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        if (!File.Exists(path))
        {
            Debug.LogError("save folder not found in " + path+ " ... Creating path!");
            Directory.CreateDirectory(path);
        }
        path = path + "/data" + saveslot + ".Blu";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData();

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static GameData load(string path, int saveslot)
    {
        path = path + "/data"+saveslot+".Blu";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;  
            stream.Close();
            return data;

        }
        else
        {
            Debug.LogError("save File not found in " + path);
            return null;
        }
    }

}
