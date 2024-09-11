using System;
using UnityEngine;
public class GeneralSingleton : MonoBehaviour
{
    public static GeneralSingleton generalSingleton;
    public int[] _num = new int[5];
    public int CaseValue, _kingdomIndex;
    public bool isNewGame, isLoadGame, isMyProfile, isFirtsTime, wasFirtsTime;
    public bool[] iscloseInfo, endQuest = new bool[5];
    void Awake()
    {
        Singleton();
        MouseUnLock();
        CaseValue = -1;
    }
    public void SetIscloseInfo(int _level)
    {
        Action action = _level switch
        {
            14 or 16 or 18 or 20 or 22 or 23 or 25 or 27 or 29 or 31 or 33 or 34 or 36 or 38 or 40 or 42 or 44
            or 45 or 47 or 49 or 51 or 53 or 55 or 56 => () => iscloseInfo[_kingdomIndex] = false,
            _ => () => Debug.Log("iscloseInfo[_kingdomIndex] = ," + iscloseInfo[_kingdomIndex]),
        };
        action();
    }
    void Singleton()
    {
        if (generalSingleton == null)
        {
            generalSingleton = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void MouseLockRotate() => SetCursorState(false, CursorLockMode.None);
    public void MouseLock() => SetCursorState(false, CursorLockMode.Locked);
    public void MouseUnLock() => SetCursorState(true, CursorLockMode.None);
    void SetCursorState(bool _bool, CursorLockMode Mode)
    {
        Cursor.visible = _bool;
        Cursor.lockState = Mode;
    }
}