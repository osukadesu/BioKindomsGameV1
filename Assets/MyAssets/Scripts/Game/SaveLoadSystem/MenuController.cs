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
        string datapath = Application.persistentDataPath + "/player.data";
        if (File.Exists(datapath))
        {
            File.Delete(Application.persistentDataPath + "/player.data");
            AssetDatabase.Refresh(); //delete This AssetDatabase.Refresh();
        }
        else Debug.Log("Not delete player.");
    }
}