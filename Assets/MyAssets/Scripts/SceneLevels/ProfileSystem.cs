using System;
using System.IO;
using UnityEngine;
public class ProfileSystem : MonoBehaviour
{
    [SerializeField] ProfileAnimations levelAnimations;
    [SerializeField] LoadProfile loadLevel;
    [SerializeField] LoadControllerProfile loadLevelSelect;
    [SerializeField] MouseController mouseController;
    public int currentLevel, _subLevel, _levelFinished;
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
        string datapath = Application.persistentDataPath + "/score.data";
        if (loadLevelSelect.LoadProfile && File.Exists(datapath))
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
    public void ShowLevel(int level)
    {
        Debug.Log("Current Level: " + level);
        Action action = level switch
        {
            1 or 2 => () => LevelAnimations(null, null),
            3 or 4 => () => SetAnimSubLevels(1),
            5 or 6 => () => SetAnimSubLevels(2),
            7 or 8 => () => SetAnimSubLevels(3),
            9 or 10 => () => SetAnimSubLevels(4),
            11 or 12 => () => SetAnimFinish(1),
            13 or 14 => () => { SetAnimFinish(1); SetAnimSubLevels(6); }
            ,
            _ => () => Debug.Log("Case Default!")
        };
        action();
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
        _subLevel = subLevel ?? _subLevel;
        levelAnimations.SubLevel(_subLevel);
        _levelFinished = levelFinished ?? _levelFinished;
        levelAnimations.LevelFinished(_levelFinished);
    }
}