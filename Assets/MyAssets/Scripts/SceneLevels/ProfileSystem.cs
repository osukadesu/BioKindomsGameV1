using UnityEngine;
public class ProfileSystem : MonoBehaviour
{
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
            case 3:
                SetAnimSubLevels(1);
                break;
            case 5:
                SetAnimSubLevels(2);
                break;
            case 7:
                SetAnimSubLevels(3);
                break;
            case 9:
                SetAnimSubLevels(4);
                break;
            case 11:
                SetAnimFinish(1);
                break;
            case 12:
                SetAnimFinish(1);
                break;
            case 14:
                SetAnimFinish(1);
                SetAnimSubLevels(6);
                break;
            default:
                LevelAnimations(null, null);
                break;
        }
    }
    void SetAnimFinish(int _length)
    {
        for (int i = 0; i < _length; i++)
        {
            LevelAnimations(null, i);
        }
    }
    void SetAnimSubLevels(int _length)
    {
        for (int i = 0; i < _length; i++)
        {
            LevelAnimations(i, null);
        }
    }
    void LevelAnimations(int? subLevel, int? levelFinished)
    {
        if (subLevel.HasValue)
        {
            levelAnimations.SubLevel(subLevel.Value);
        }
        if (levelFinished.HasValue)
        {
            levelAnimations.LevelFinished(levelFinished.Value);
        }
    }
}