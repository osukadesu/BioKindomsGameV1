using System;
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
        Action action = level switch
        {
            3 => () => SetAnimSubLevels(1),
            5 => () => SetAnimSubLevels(2),
            7 => () => SetAnimSubLevels(3),
            9 => () => SetAnimSubLevels(4),
            11 => () => SetAnimFinish(1),
            12 => () => SetAnimFinish(1),
            14 => () => { SetAnimFinish(1); SetAnimSubLevels(6); }
            ,
            _ => () => LevelAnimations(null, null)
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