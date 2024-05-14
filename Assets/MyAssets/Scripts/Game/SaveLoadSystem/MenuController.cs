using System.IO;
//using UnityEditor;
using UnityEngine;
public class MenuController : MonoBehaviour
{
    public static MenuController menuController;
    [SerializeField] bool isNewGame, isLoadGame, isSavingGame, isInfo;
    [SerializeField] int btnId;
    public bool IsNewGame { get => isNewGame; set => isNewGame = value; }
    public bool IsLoadGame { get => isLoadGame; set => isLoadGame = value; }
    public bool IsSavingGame { get => isSavingGame; set => isSavingGame = value; }
    public bool IsInfo { get => isInfo; set => isInfo = value; }
    public int _btnId { get => btnId; set => btnId = value; }
    void Awake()
    {
        Singleton();
        isNewGame = false;
        isLoadGame = false;
        isSavingGame = false;
        IsInfo = false;
        DeleteLevelData();
        MouseUnLock();
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
    protected internal void DeleteLevelData()
    {
        DeleteV1();
        DeleteV2();
    }
    void DeleteV1()
    {
        string datapath = Application.persistentDataPath + "/level.data";
        if (!isNewGame && !isLoadGame && File.Exists(datapath))
        {
            File.Delete(Application.persistentDataPath + "/level.data");
            //AssetDatabase.Refresh();
        }
        else Debug.Log("Not delete level.");
    }
    void DeleteV2()
    {
        string datapath = Application.persistentDataPath + "/levelgame.data";
        if (!isNewGame && !isLoadGame && File.Exists(datapath))
        {
            File.Delete(Application.persistentDataPath + "/levelgame.data");
            //AssetDatabase.Refresh();
        }
        else Debug.Log("Not delete level.");
    }
    void MouseUnLock()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}