using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SaveAndLoadManager
{
    public static void SaveLevel(LevelSystemV2 levelSystem)
    {
        PlayerData playerData = new(levelSystem);
        string datapath = Application.persistentDataPath + "/level.data";
        FileStream fileStream = new(datapath, FileMode.Create);
        BinaryFormatter binaryFormatter = new();
        binaryFormatter.Serialize(fileStream, playerData);
        Debug.Log("Save Level");
        fileStream.Close();
    }
    public static PlayerData LoadLevel()
    {
        string datapath = Application.persistentDataPath + "/level.data";
        if (File.Exists(datapath))
        {
            FileStream fileStream = new(datapath, FileMode.Open);
            BinaryFormatter binaryFormatter = new();
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            Debug.Log("Load Level");
            return playerData;
        }
        else
        {
            Debug.LogError("Level is missing!");
            return null;
        }
    }
    public static void SaveForLevelGame(LevelSystemV2 levelSystem, InventoryItemDataV2[] inventoryItemDataV2)
    {
        PlayerData playerData = new(levelSystem, inventoryItemDataV2);
        string datapath = Application.persistentDataPath + "/levelgame.data";
        FileStream fileStream = new(datapath, FileMode.Create);
        BinaryFormatter binaryFormatter = new();
        binaryFormatter.Serialize(fileStream, playerData);
        Debug.Log("Save Level Game");
        fileStream.Close();
    }
    public static PlayerData LoadLevelGame()
    {
        string datapath = Application.persistentDataPath + "/levelgame.data";
        if (File.Exists(datapath))
        {
            FileStream fileStream = new(datapath, FileMode.Open);
            BinaryFormatter binaryFormatter = new();
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            Debug.Log("Load Level Game");
            return playerData;
        }
        else
        {
            Debug.LogError("Level is missing!");
            return null;
        }
    }
    public static void SaveDataGame(LevelSystemV2 levelSystem, InventoryItemDataV2[] inventoryItemDataV2)
    {
        PlayerData playerData = new(levelSystem, inventoryItemDataV2);
        string datapath = Application.persistentDataPath + "/player.data";
        FileStream fileStream = new(datapath, FileMode.Create);
        BinaryFormatter binaryFormatter = new();
        binaryFormatter.Serialize(fileStream, playerData);
        Debug.Log("Save Game");
        fileStream.Close();
    }
    public static PlayerData LoadDataGame()
    {
        string datapath = Application.persistentDataPath + "/player.data";
        if (File.Exists(datapath))
        {
            FileStream fileStream = new(datapath, FileMode.Open);
            BinaryFormatter binaryFormatter = new();
            PlayerData playerData = (PlayerData)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();
            Debug.Log("Load Game");
            return playerData;
        }
        else
        {
            Debug.LogError("No se encontró la partida");
            return null;
        }
    }
}