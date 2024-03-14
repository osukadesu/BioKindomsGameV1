using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour
{
    [SerializeField] LevelController _levelController;
    [SerializeField] LevelAnimations levelAnimations;
    [SerializeField] LoadLevelSelect loadLevel;
    [SerializeField] Button[] btnGoGame;
    [SerializeField] LoadControllerLevelSelect loadLevelSelect;
    [SerializeField] MouseController mouseController;
    [SerializeField] EscapeLogicV2 escapeLogicV2;
    public int currentLevel, btnLevel;
    void Awake()
    {
        escapeLogicV2 = FindObjectOfType<EscapeLogicV2>();
        mouseController = FindObjectOfType<MouseController>();
        loadLevel = FindObjectOfType<LoadLevelSelect>();
    }
    void Start()
    {
        InitialButtons();
        escapeLogicV2.CanEscape = true;
        mouseController.MouseUnLock();
        ReadLevel();
    }
    void InitialButtons()
    {
        for (int i = 0; i < btnGoGame.Length; i++)
        {
            btnGoGame[i].onClick.AddListener(() => _levelController.ButtonGoGame());
        }
    }
    void ReadLevel()
    {
        string datapath = Application.persistentDataPath + "/level.data";
        if (File.Exists(datapath))
        {
            loadLevel.GoLoadLevelSelect();
        }
        else
        {
            if (loadLevelSelect.LevelLoad)
            {
                loadLevel.GoLoadGame();
            }
            else
            {
                if (File.Exists(datapath) && !loadLevelSelect.LevelLoad)
                {
                    loadLevel.GoLoadLevelSelect();
                }
                else
                {
                    if (!loadLevelSelect.LevelLoad)
                    {
                        AllBtnFalse();
                        loadLevel.GoNewGameAndLevel();
                    }
                }
            }
        }
    }
    void AllBtnFalse()
    {
        for (int i = 1; i < btnGoGame.Length; i++)
        {
            btnGoGame[i].enabled = false;
        }
    }
    public void Configure(LevelController levelController)
    {
        _levelController = levelController;
    }
    public void GoGame()
    {
        SceneManager.LoadScene(3);
    }
    public void ShowLevel(int level)
    {
        switch (level)
        {
            case 1:
                LevelAnimations(1, null, null);
                break;
            case 2:
                LevelAnimations(1, 0, null);
                break;
            case 3:
                LevelAnimations(2, 0, 0);
                break;
            case 4:
                LevelAnimations(2, 0, 0);
                break;
            case 5:
                LevelAnimations(2, 0, 0);
                break;
            case 6:
                LevelAnimations(2, 0, 0);
                break;
            case 7:
                LevelAnimations(2, 0, 0);
                break;
            case 8:
                LevelAnimations(2, 0, 0);
                break;
            case 9:
                LevelAnimations(2, 0, 0);
                break;
            case 10:
                LevelAnimations(2, 0, 0);
                break;
            case 11:
                LevelAnimations(2, 0, 0);
                break;
            case 12:
                LevelAnimations(2, 2, 0);
                break;
            default:
                LevelAnimations(1, 0, null);
                break;
        }
        SetButtonStates();
    }
    void SetButtonStates()
    {
        for (int i = 0; i < btnGoGame.Length; i++)
        {
            btnGoGame[i].enabled = i == btnLevel - 1;
        }
    }
    void LevelAnimations(int? _btnLevel, int? _subLevel, int? _levelFinished)
    {
        if (_btnLevel.HasValue)
        {
            btnLevel = _btnLevel.Value;
        }
        if (_subLevel.HasValue)
        {
            levelAnimations.SubLevel(_subLevel.Value);
        }
        if (_levelFinished.HasValue)
        {
            levelAnimations.LevelFinished(_levelFinished.Value);
        }
    }
}

/*
     public void ShowLevel(int level)
    {
        switch (level)
        {
            case 1:
                LevelAnimations(1, null, null);
                break;
            case 2:
                LevelAnimations(1, 0, null);
                break;
            case 3:
                LevelAnimations(2, 0, 0);
                LevelAnimations(null, 1, null);
                break;
            case 4:
                LevelAnimations(2, 2, 0);
                break;
            case 5:
                LevelAnimations(2, 2, 0);
                LevelAnimations(null, 3, null);
                break;
            case 6:
                LevelAnimations(2, 2, 0);
                LevelAnimations(null, 3, null);
                break;
            case 7:
                LevelAnimations(2, 2, 0);
                LevelAnimations(null, 3, null);
                LevelAnimations(null, 4, null);
                break;
            case 8:
                LevelAnimations(2, 2, 0);
                LevelAnimations(null, 3, null);
                LevelAnimations(null, 4, null);
                break;
            case 9:
                LevelAnimations(2, 2, 0);
                LevelAnimations(null, 3, null);
                LevelAnimations(null, 4, null);
                LevelAnimations(null, 5, null);
                break;
            case 10:
                LevelAnimations(2, 2, 0);
                LevelAnimations(null, 3, null);
                LevelAnimations(null, 4, null);
                LevelAnimations(null, 5, null);
                break;
            case 11:
                LevelAnimations(2, 2, 0);
                LevelAnimations(null, 3, null);
                LevelAnimations(null, 4, null);
                LevelAnimations(null, 5, null);
                LevelAnimations(null, 6, null);
                break;
            case 12:
                LevelAnimations(1, 0, null);
                LevelAnimations(null, null, 0);
                LevelAnimations(3, 7, 1);
                break;
            default:
                LevelAnimations(1, null, null);
                break;
        }
        SetButtonStates();
    }
*/