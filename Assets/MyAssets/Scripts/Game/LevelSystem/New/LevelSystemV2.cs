using System.Collections;
using System.IO;
using UnityEngine;
public class LevelSystemV2 : MonoBehaviour
{
    [SerializeField] GameObject platformBase, platformFight;
    [SerializeField] LoadControllerGame loadController;
    [SerializeField] ShowLevelCaseV2 showLevelCaseV2;
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] protected MouseController mouseController;
    int currentLevel;
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    void Awake()
    {
        loadController = FindObjectOfType<LoadControllerGame>();
        loadLevelSystem = FindObjectOfType<LoadLevelSystem>();
        showLevelCaseV2 = FindObjectOfType<ShowLevelCaseV2>();
        mouseController = FindObjectOfType<MouseController>();
        mouseController.MouseLock();
    }
    void Start()
    {
        ReadData();
        platformBase.SetActive(true);
        platformFight.SetActive(false);
        ElementsHide();
    }
    void ReadData()
    {
        string datapath = Application.persistentDataPath + "/player.data";
        string datapath2 = Application.persistentDataPath + "/quest.data";
        if (File.Exists(datapath) && !loadController.LevelLoadGame || File.Exists(datapath2) && !loadController.LevelLoadGame)
        {
            loadLevelSystem.GoLoadGame();
        }
        else
        {
            if (loadController.LevelLoadGame)
            {
                loadLevelSystem.GoLoadGame();
            }
            else
            {
                if (!loadController.LevelLoadGame)
                {
                    loadLevelSystem.GoNewGame();
                }
            }
        }
    }
    void ElementsHide()
    {
        for (int i = 0; i < showLevelCaseV2.money.Length; i++)
        {
            showLevelCaseV2.money[i].SetActive(false);
        }
        for (int i = 0; i < showLevelCaseV2.enemy.Length; i++)
        {
            showLevelCaseV2.enemy[i].SetActive(false);
        }
    }
    protected internal void ChangeLevel()
    {
        currentLevel++;
        showLevelCaseV2.ShowLevel(currentLevel);
        Debug.Log("currentLevelChanged = " + currentLevel);
    }
}