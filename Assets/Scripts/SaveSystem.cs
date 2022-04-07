using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using System.IO;

public class SaveSystem 
{
    public static void savePlayer(PlayerMovement player)
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(player);
        Formatter.Serialize(stream, data);
        stream.Close();
    }
    public static playerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/playerData.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

           playerData data = formatter.Deserialize(stream) as playerData;
            stream.Close();

            return data;
            
        }
        else
        {
            Debug.LogError("Save File not found");
            return null;
        }
    }
}
