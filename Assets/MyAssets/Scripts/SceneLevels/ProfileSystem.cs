using UnityEngine;
public class ProfileSystem : MonoBehaviour
{
    [SerializeField] ScoreSystem scoreSystem;
    [SerializeField] ProfileAnimations levelAnimations;
    [SerializeField] LoadProfile loadLevel;
    [SerializeField] LoadControllerProfile loadLevelSelect;
    [SerializeField] MouseController mouseController;
    public int currentLevel;
    void Awake()
    {
        mouseController = FindObjectOfType<MouseController>();
        loadLevel = FindObjectOfType<LoadProfile>();
    }
    void Start()
    {
        ReadData();
        mouseController.MouseUnLock();
    }
    void ReadData()
    {
        if (loadLevelSelect.LoadProfile)
        {
            loadLevel.GoLoadProfile();
        }
        else
        {
            if (!loadLevelSelect.LoadProfile)
            {
                loadLevel.GoNewProfile();
            }
        }
    }
    public void ShowLevel(int level)
    {
        Debug.Log("Current Level: " + level);
        switch (level)
        {
            case 1:
                LevelAnimations(null, null);
                break;
            case 2:
                LevelAnimations(1, 1);
                break;
            case 3:
                LevelAnimations(1, 1);
                break;
            case 4:
                LevelAnimations(0, 0);
                break;
            case 5:
                LevelAnimations(0, 0);
                break;
            case 6:
                LevelAnimations(0, 0);
                break;
            case 7:
                LevelAnimations(0, 0);
                break;
            case 8:
                LevelAnimations(0, 0);
                break;
            case 9:
                LevelAnimations(0, 0);
                break;
            case 10:
                LevelAnimations(0, 0);
                break;
            default:
                LevelAnimations(null, null);
                break;
        }
    }
    void LevelAnimations(int? _subLevel, int? _levelFinished)
    {
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