using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public static class BinarySavingStatistics
{
    public static void SaveStatistics()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/StatisticsData.nm";
        FileStream stream = new FileStream(path, FileMode.Create);

        StatisticsData data = new StatisticsData();//

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static StatisticsData LoadStatistics()
    {
        string path = Application.persistentDataPath + "/StatisticsData.nm";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            StatisticsData data = formatter.Deserialize(stream) as StatisticsData;//
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
