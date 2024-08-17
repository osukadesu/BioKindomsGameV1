using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
public static class SaveScoreData
{
    public static void SaveScore(CompareState compareState, GeneralSingleton generalSingleton)
    {
        ScoreData scoreData = new(compareState, generalSingleton);
        string datapath = Application.persistentDataPath + "/score.data";
        FileStream fileStream = new(datapath, FileMode.Create);
        BinaryFormatter binaryFormatter = new();
        binaryFormatter.Serialize(fileStream, scoreData);
        Debug.Log("Save Score");
        fileStream.Close();
    }
    public static ScoreData LoadScore()
    {
        string datapath = Application.persistentDataPath + "/score.data";
        if (File.Exists(datapath))
        {
            FileStream fileStream = new(datapath, FileMode.Open);
            BinaryFormatter binaryFormatter = new();
            ScoreData scoreData = (ScoreData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            Debug.Log("Load Score");
            return scoreData;
        }
        else
        {
            Debug.LogError("score is missing!");
            return null;
        }
    }
}