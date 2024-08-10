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
            case 1:
                LevelAnimations(null, null);
                break;
            case 2:
                LevelAnimations(null, null);
                break;
            case 3:
                LevelAnimations(0, null);
                break;
            case 4:
                LevelAnimations(0, null);
                break;
            case 5:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                break;
            case 6:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                break;
            case 7:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                LevelAnimations(2, null);
                break;
            case 8:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                LevelAnimations(2, null);
                break;
            case 9:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                LevelAnimations(2, null);
                LevelAnimations(3, null);
                break;
            case 10:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                LevelAnimations(2, null);
                LevelAnimations(3, null);
                break;
            case 11:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                LevelAnimations(2, null);
                LevelAnimations(3, null);
                LevelAnimations(4, null);
                break;
            case 12:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                LevelAnimations(2, null);
                LevelAnimations(3, null);
                LevelAnimations(4, null);
                break;
            case 13:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                LevelAnimations(2, null);
                LevelAnimations(3, null);
                LevelAnimations(4, null);
                break;
            case 14:
                LevelAnimations(0, null);
                LevelAnimations(1, null);
                LevelAnimations(2, null);
                LevelAnimations(3, null);
                LevelAnimations(4, null);
                LevelAnimations(5, null);
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