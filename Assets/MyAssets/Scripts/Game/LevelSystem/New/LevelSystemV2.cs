using System.Collections;
using System.IO;
using UnityEngine;
public class LevelSystemV2 : MonoBehaviour
{
    [SerializeField] GameObject platformBase, platformFight;
    [SerializeField] LoadControllerGame loadController;
    [SerializeField] ShowLevelCaseV2 showLevelCaseV2;
    [SerializeField] LoadLevelSystem loadLevelSystem;
    int currentLevel;
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    void Awake()
    {
        ReadLevel();
    }
    void Start()
    {
        currentLevel = 1;
        platformBase.SetActive(true);
        platformFight.SetActive(false);
    }
    void ReadLevel()
    {
        string datapath = Application.persistentDataPath + "/levelgame.data";
        if (File.Exists(datapath))
        {
            loadLevelSystem.GoLoadLevel();
        }
        else
        {
            if (loadController.LevelLoad)
            {
                loadLevelSystem.GoLoadGame();
            }
            else
            {
                if (File.Exists(datapath) && !loadController.LevelLoad)
                {
                    loadLevelSystem.GoLoadLevel();
                }
                else
                {
                    if (!loadController.LevelLoad)
                    {
                        loadLevelSystem.GoNewGameAndLevel();
                    }
                }
            }
        }
    }
    protected internal void ChangeLevel()
    {
        currentLevel++;
        showLevelCaseV2.ShowLevel(currentLevel);
        Debug.Log("currentLevelChanged = " + currentLevel);
    }
}