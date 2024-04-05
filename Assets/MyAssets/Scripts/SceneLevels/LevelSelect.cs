using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour
{
    [SerializeField] LevelController _levelController;
    [SerializeField] LevelAnimations levelAnimations;
    [SerializeField] LoadLevelSelect loadLevel;
    [SerializeField] Button[] btnGoGameOrQuest;
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
        for (int i = 0; i < btnGoGameOrQuest.Length; i++)
        {
            switch (i)
            {
                case 0:
                    btnGoGameOrQuest[i].onClick.AddListener(() => _levelController.ButtonGoGameOrQuest(0));
                    break;
                case 1:
                    btnGoGameOrQuest[i].onClick.AddListener(() => _levelController.ButtonGoGameOrQuest(0));
                    break;
                case 2:
                    btnGoGameOrQuest[i].onClick.AddListener(() => _levelController.ButtonGoGameOrQuest(1));
                    break;
            }
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
        for (int i = 1; i < btnGoGameOrQuest.Length; i++)
        {
            btnGoGameOrQuest[i].enabled = false;
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
    public void GoQuest()
    {
        SceneManager.LoadScene(4);
    }
    public void ShowLevel(int level)
    {
        switch (level)
        {
            case 1:
                LevelAnimations(1, null, null, 0);
                break;
            case 2:
                LevelAnimations(1, 0, null, 0);
                break;
            case 3:
                LevelAnimations(2, 0, 0, 0);
                LevelAnimations(null, 1, null, 0);
                break;
            case 4:
                LevelAnimations(2, 2, 0, 0);
                break;
            case 5:
                LevelAnimations(2, 2, 0, 0);
                LevelAnimations(null, 3, null, 0);
                break;
            case 6:
                LevelAnimations(2, 2, 0, 0);
                LevelAnimations(null, 3, null, 0);
                break;
            case 7:
                LevelAnimations(2, 2, 0, 0);
                LevelAnimations(null, 3, null, 0);
                LevelAnimations(null, 4, null, 0);
                break;
            case 8:
                LevelAnimations(2, 2, 0, 0);
                LevelAnimations(null, 3, null, 0);
                LevelAnimations(null, 4, null, 0);
                break;
            case 9:
                LevelAnimations(2, 2, 0, 0);
                LevelAnimations(null, 3, null, 0);
                LevelAnimations(null, 4, null, 0);
                LevelAnimations(null, 5, null, 0);
                break;
            case 10:
                LevelAnimations(2, 2, 0, 0);
                LevelAnimations(null, 3, null, 0);
                LevelAnimations(null, 4, null, 0);
                LevelAnimations(null, 5, null, 0);
                break;
            case 11:
                LevelAnimations(2, 2, 0, 0);
                LevelAnimations(null, 3, null, 0);
                LevelAnimations(null, 4, null, 0);
                LevelAnimations(null, 5, null, 0);
                LevelAnimations(null, 6, null, 0);
                break;
            case 12:
                LevelAnimations(2, null, 0, 0);
                LevelAnimations(2, null, 1, 0);
                LevelAnimations(3, null, 1, 1);
                break;
            default:
                LevelAnimations(1, 0, null, 0);
                break;
        }
        SetButtonStates();
    }
    void SetButtonStates()
    {
        for (int i = 0; i < btnGoGameOrQuest.Length; i++)
        {
            btnGoGameOrQuest[i].enabled = i == btnLevel - 1;
        }
    }
    void LevelAnimations(int? _btnLevel, int? _subLevel, int? _levelFinished, int? _version)
    {
        if (_btnLevel.HasValue)
        {
            btnLevel = _btnLevel.Value;
        }
        if (_subLevel.HasValue)
        {
            levelAnimations.SubLevel(_subLevel.Value);
        }
        if (_levelFinished.HasValue && _version.HasValue)
        {
            levelAnimations.LevelFinished(_levelFinished.Value, _version.Value);
        }
    }
}