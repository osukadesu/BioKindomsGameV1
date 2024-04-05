using System.IO;
using UnityEngine;
public class LevelSystem : MonoBehaviour
{
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] ShowLevelSystem showLevelSystem;
    [SerializeField] ShowLevelCase showLevelCase;
    [SerializeField] LoadControllerGame loadController;
    [SerializeField] EscapeLogicV1 escapeLogicV1;
    [SerializeField] int currentLevel;
    public int CurrentLevel { get => currentLevel; set => currentLevel = value; }
    void Awake()
    {
        loadLevelSystem = FindObjectOfType<LoadLevelSystem>();
        showLevelSystem = FindObjectOfType<ShowLevelSystem>();
        loadController = FindObjectOfType<LoadControllerGame>();
        showLevelCase = FindObjectOfType<ShowLevelCase>();
        escapeLogicV1 = FindObjectOfType<EscapeLogicV1>();
        escapeLogicV1.CanEscape = true;
    }
    void Start()
    {
        ElementsHide();
        ReadLevel();
    }
    void ElementsHide()
    {
        for (int i = 0; i < showLevelSystem.money.Length; i++)
        {
            showLevelSystem.money[i].SetActive(false);
        }
        for (int i = 0; i < showLevelSystem.enemy.Length; i++)
        {
            showLevelSystem.enemy[i].SetActive(false);
        }
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
        showLevelCase.ShowLevel(currentLevel);
        Debug.Log("currentLevelChanged = " + currentLevel);
    }
}