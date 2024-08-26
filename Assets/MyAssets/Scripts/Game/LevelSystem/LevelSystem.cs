using System.IO;
using UnityEngine;
public class LevelSystem : MonoBehaviour
{
    [SerializeField] LoadControllerGame loadController;
    [SerializeField] LevelDisplay levelDisplay;
    [SerializeField] LoadLevelSystem loadLevelSystem;
    int currentLevel;
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    void Awake()
    {
        loadController = FindObjectOfType<LoadControllerGame>();
        loadLevelSystem = FindObjectOfType<LoadLevelSystem>();
        levelDisplay = FindObjectOfType<LevelDisplay>();
        GeneralSingleton.generalSingleton.MouseLock();
    }
    void Start() => ReadData();
    void ReadData()
    {
        string datapath = Application.persistentDataPath + "/level.data";
        if (File.Exists(datapath) && !loadController.LevelLoadGame)
        {
            loadLevelSystem.GoLoadGame();
        }
        else
        {
            if (!loadController.LevelLoadGame)
            {
                loadLevelSystem.GoNewGame();
            }
            else
            {
                loadLevelSystem.GoLoadGame();
            }
        }
    }
    public void ChangeLevel()
    {
        currentLevel++;
        levelDisplay.ShowLevel(currentLevel);
        Debug.Log("currentLevelChanged = " + currentLevel);
    }
}