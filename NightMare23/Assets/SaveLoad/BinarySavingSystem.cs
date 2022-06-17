using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class BinarySavingSystem
{
    public static void SavePlayer(Player player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.nm";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);//

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.nm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;//
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }


    public static void SaveScene(Transform parentObject)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/Scene" + SceneManager.GetActiveScene().buildIndex + ".nm";
        FileStream stream = new FileStream(path, FileMode.Create);

        SceneData data = new SceneData(parentObject);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static SceneData LoadScene()
    {
        string path = Application.persistentDataPath + "/Scene" + SceneManager.GetActiveScene().buildIndex + ".nm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            SceneData data = formatter.Deserialize(stream) as SceneData;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }


}
