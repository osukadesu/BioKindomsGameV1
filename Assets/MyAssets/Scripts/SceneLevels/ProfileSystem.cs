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
            3 or 4 => () => SetAnimSubLevels(1, isLoad),
            5 or 6 => () => SetAnimSubLevels(2, isLoad),
            7 or 8 => () => SetAnimSubLevels(3, isLoad),
            9 or 10 => () => SetAnimSubLevels(4, isLoad),
            11 or 12 => () => SetAnimFinish(1, isLoad),
            13 or 14 => () => { SetAnimFinish(1, isLoad); SetAnimSubLevels(6, isLoad); }
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