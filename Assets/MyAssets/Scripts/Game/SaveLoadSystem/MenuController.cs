using System.IO;
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
        string[] fileNames = { Application.persistentDataPath + "/player.data", Application.persistentDataPath + "/level.data", Application.persistentDataPath + "/quest.data", Application.persistentDataPath + "/score.data" };
        for (int i = 0; i < fileNames.Length; i++)
        {
            if (File.Exists(fileNames[i]))
            {
                File.Delete(fileNames[i]);
            }
        }
    }
}