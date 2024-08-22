using System;
using System.IO;
using UnityEngine;
public class ProfileSystem : MonoBehaviour
{
    [SerializeField] ProfileAnimations levelAnimations;
    [SerializeField] LoadProfile loadLevel;
    [SerializeField] LoadControllerProfile loadLevelSelect;
    public int currentLevel;
    void Awake()
    {
        loadLevel = FindObjectOfType<LoadProfile>();
    }
    void Start()
    {
        ReadData();
        GeneralSingleton.generalSingleton.MouseUnLock();
    }
    void ReadData()
    {
        string datapath = Application.persistentDataPath + "/score.data";
        if (loadLevelSelect.LoadProfile && File.Exists(datapath) && !GeneralSingleton.generalSingleton.wasFirtsTime)
        {
            loadLevel.GoLoadProfile();
        }
        else
        {
            if (loadLevelSelect.LoadProfile && !File.Exists(datapath))
            {
                loadLevel.GoNewProfile();
            }
        }
    }
    public void ShowLevel(int level, bool isLoad)
    {
        Debug.Log("Profile Level: " + level);
        Action action = level switch
        {
            1 or 2 => () => LevelAnimations(null, null, isLoad),

            3 => () => SetAnimSubLevels(1, isLoad),
            5 => () => SetAnimSubLevels(2, isLoad),
            7 => () => SetAnimSubLevels(3, isLoad),
            9 => () => SetAnimSubLevels(4, isLoad),
            11 or 12 => () => SetAnimSubLevels(5, isLoad),
            14 => () => SetAnimSubLevels(6, isLoad),
            16 => () => SetAnimSubLevels(7, isLoad),
            18 => () => SetAnimSubLevels(8, isLoad),
            20 => () => SetAnimSubLevels(9, isLoad),
            22 or 23 => () => SetAnimSubLevels(10, isLoad),
            25 => () => SetAnimSubLevels(11, isLoad),
            27 => () => SetAnimSubLevels(12, isLoad),
            29 => () => SetAnimSubLevels(13, isLoad),
            31 => () => SetAnimSubLevels(14, isLoad),
            33 or 34 => () => SetAnimSubLevels(15, isLoad),
            36 => () => SetAnimSubLevels(16, isLoad),
            38 => () => SetAnimSubLevels(17, isLoad),
            40 => () => SetAnimSubLevels(18, isLoad),
            42 => () => SetAnimSubLevels(19, isLoad),
            44 or 45 => () => SetAnimSubLevels(20, isLoad),
            47 => () => SetAnimSubLevels(21, isLoad),
            49 => () => SetAnimSubLevels(22, isLoad),
            51 => () => SetAnimSubLevels(23, isLoad),
            53 => () => SetAnimSubLevels(24, isLoad),
            55 or 56 => () => SetAnimSubLevels(25, isLoad),
            _ => () => Debug.Log("ShowLevel case default!"),
        };
        action();
        SetOnlyAnimFinish(level, isLoad);
    }
    void SetOnlyAnimFinish(int level, bool isLoad)
    {
        Action action = level switch
        {
            11 or 12 or 13 or 14 or 15 or 16 or 17 or 18 or 19 or 20 => () => SetAnimFinish(1, isLoad),
            21 or 22 or 23 or 24 or 25 or 26 or 27 or 28 or 29 or 30 => () =>
            {
                SetAnimFinish(1, isLoad);
                SetAnimFinish(2, isLoad);
            }
            ,
            31 or 32 or 33 or 34 or 35 or 36 or 37 or 38 or 39 or 40 => () =>
            {
                SetAnimFinish(1, isLoad);
                SetAnimFinish(2, isLoad);
                SetAnimFinish(3, isLoad);
            }
            ,
            41 or 42 or 43 or 44 or 45 or 46 or 47 or 48 or 49 or 50 => () =>
            {
                SetAnimFinish(1, isLoad);
                SetAnimFinish(2, isLoad);
                SetAnimFinish(3, isLoad);
                SetAnimFinish(4, isLoad);
            }
            ,
            51 or 52 or 53 or 54 or 55 or 56 => () =>
            {
                SetAnimFinish(1, isLoad);
                SetAnimFinish(2, isLoad);
                SetAnimFinish(3, isLoad);
                SetAnimFinish(4, isLoad);
                SetAnimFinish(5, isLoad);
            }
            ,
            _ => () => Debug.Log("ShowLevel case default!"),
        };
        action();
    }
    public void SetAnimSubLevels(int _length, bool isLoad)
    {
        for (int i = 0; i < _length; i++)
        {
            LevelAnimations(i, null, isLoad);
        }
    }
    public void SetAnimFinish(int _length, bool isLoad)
    {
        for (int i = 0; i < _length; i++)
        {
            LevelAnimations(null, i, isLoad);
        }
    }
    public void LevelAnimations(int? subLevel, int? levelFinished, bool isLoad)
    {
        if (subLevel.HasValue)
        {
            levelAnimations.SubLevel(subLevel.Value, isLoad);
        }
        if (levelFinished.HasValue)
        {
            levelAnimations.LevelFinished(levelFinished.Value, isLoad);
        }
    }
}