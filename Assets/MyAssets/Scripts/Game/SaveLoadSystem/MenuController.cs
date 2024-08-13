using System;
using System.IO;
using UnityEditor;
using UnityEngine;
public class MenuController : MonoBehaviour
{
    public static MenuController menuController;
    [SerializeField] bool isNewGame, isLoadGame, isMyProfile;
    public bool IsNewGame { get => isNewGame; set => isNewGame = value; }
    public bool IsLoadGame { get => isLoadGame; set => isLoadGame = value; }
    public bool IsMyProfile { get => isMyProfile; set => isMyProfile = value; }
    void Awake()
    {
        Singleton(); isNewGame = false; isLoadGame = false; isMyProfile = false;
        Cursor.visible = true; Cursor.lockState = CursorLockMode.None;
    }
    void Singleton()
    {
        if (menuController == null)
        {
            menuController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void DeletePlayerData()
    {
        string[] fileNames = { "/player.data", "/level.data", "/quest.data", "/score.data" };
        foreach (var fileName in fileNames)
        {
            string filePath = Path.Combine(Application.persistentDataPath, fileName);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
        AssetDatabase.Refresh();
    }
}