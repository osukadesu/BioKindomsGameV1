using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelSelect : MonoBehaviour
{
    [SerializeField] LevelController _levelController;
    [SerializeField] LevelAnimations levelAnimations;
    [SerializeField] LoadLevelSelect loadLevel;
    [SerializeField] LoadControllerLevelSelect loadLevelSelect;
    [SerializeField] MouseController mouseController;
    [SerializeField] EscapeLogicV2 escapeLogicV2;
    [SerializeField] Button[] btnLevelSelect;
    [SerializeField] bool questFinished;
    public int currentLevel, btnLevel;
    void Awake()
    {
        escapeLogicV2 = FindObjectOfType<EscapeLogicV2>();
        mouseController = FindObjectOfType<MouseController>();
        loadLevel = FindObjectOfType<LoadLevelSelect>();
    }
    void Start()
    {
        questFinished = false;
        InitialButtons();
        escapeLogicV2.CanEscape = true;
        mouseController.MouseUnLock();
        ReadLevel();
    }
    void InitialButtons()
    {
        for (int i = 0; i < btnLevelSelect.Length; i++)
        {
            switch (i)
            {
                case 0:
                    btnLevelSelect[i].onClick.AddListener(() => _levelController.ButtonGoGameOrQuest(0));
                    break;
                case 1:
                    btnLevelSelect[i].onClick.AddListener(() => _levelController.ButtonGoGameOrQuest(0));
                    break;
                case 2:
                    btnLevelSelect[i].onClick.AddListener(() => _levelController.ButtonGoGameOrQuest(1));
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
        for (int i = 1; i < btnLevelSelect.Length; i++)
        {
            btnLevelSelect[i].enabled = false;
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
                LevelAnimations(1, null, null, false);
                break;
            case 2:
                LevelAnimations(1, 0, null, false);
                break;
            case 3:
                LevelAnimations(2, 0, 0, false);
                LevelAnimations(null, 1, null, false);
                break;
            case 4:
                LevelAnimations(2, 2, 0, false);
                break;
            case 5:
                LevelAnimations(2, 2, 0, false);
                LevelAnimations(null, 3, null, false);
                break;
            case 6:
                LevelAnimations(2, 2, 0, false);
                LevelAnimations(null, 3, null, false);
                break;
            case 7:
                LevelAnimations(2, 2, 0, false);
                LevelAnimations(null, 3, null, false);
                LevelAnimations(null, 4, null, false);
                break;
            case 8:
                LevelAnimations(2, 2, 0, false);
                LevelAnimations(null, 3, null, false);
                LevelAnimations(null, 4, null, false);
                break;
            case 9:
                LevelAnimations(2, 2, 0, false);
                LevelAnimations(null, 3, null, false);
                LevelAnimations(null, 4, null, false);
                LevelAnimations(null, 5, null, false);
                break;
            case 10:
                LevelAnimations(2, 2, 0, false);
                LevelAnimations(null, 3, null, false);
                LevelAnimations(null, 4, null, false);
                LevelAnimations(null, 5, null, false);
                break;
            case 11:
                LevelAnimations(2, 2, 0, false);
                LevelAnimations(null, 3, null, false);
                LevelAnimations(null, 4, null, false);
                LevelAnimations(null, 5, null, false);
                LevelAnimations(null, 6, null, false);
                break;
            case 12:
                switch (questFinished)
                {
                    case true:
                        LevelAnimations(2, null, 0, false);
                        LevelAnimations(2, null, 1, false);
                        LevelAnimations(3, null, 1, false);
                        LevelAnimations(4, null, 1, true);
                        levelAnimations.OtherAnims(4, "info");
                        break;
                    case false:
                        LevelAnimations(2, null, 0, false);
                        LevelAnimations(2, null, 1, false);
                        LevelAnimations(3, null, 1, true);
                        levelAnimations.OtherAnims(3, "quest");
                        break;
                }
                break;
            default:
                LevelAnimations(1, 0, null, false);
                break;
        }
        SetButtonStates();
    }
    void SetButtonStates()
    {
        for (int i = 0; i < btnLevelSelect.Length; i++)
        {
            btnLevelSelect[i].enabled = i == btnLevel - 1;
        }
    }
    void LevelAnimations(int? _btnLevel, int? _subLevel, int? _levelFinished, bool _canRotate)
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
            levelAnimations.LevelFinished(_levelFinished.Value, _canRotate);
        }
        /*
         if (_levelFinished.HasValue && _version.HasValue)
        {
            levelAnimations.LevelFinished(_levelFinished.Value, _version.Value);
        }
        */
    }
}