using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.UI;
using System.IO;

public class SaveSystem 
{

    //Player
    public static void createPlayer()
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData();
        Formatter.Serialize(stream, data);
        stream.Close();
    }
    
    public static void savePlayerFromShop(PlayerShop player)
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(player);
        Formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void savePlayer(PlayerMovement player)
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        playerData data = new playerData(player);
        Formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void savePlayerFromMShop(playerData data)
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/playerData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

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
    //Base
    public static void createBase()
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/MothershipData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        MothershipData data = new MothershipData();
        Formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void saveBaseFromShop(mothershipShop Base)
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/MothershipData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        MothershipData data = new MothershipData(Base);
        Formatter.Serialize(stream, data);
        stream.Close();
    }
    public static void saveBase(mothership Base)
    {
        BinaryFormatter Formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/MothershipData.txt";
        FileStream stream = new FileStream(path, FileMode.Create);

        MothershipData data = new MothershipData(Base);
        Formatter.Serialize(stream, data);
        stream.Close();
    }
    public static MothershipData LoadBase()
    {
        string path = Application.persistentDataPath + "/MothershipData.txt";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MothershipData data = formatter.Deserialize(stream) as MothershipData;
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
