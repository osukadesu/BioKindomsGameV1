using UnityEngine;
public class GeneralSingleton : MonoBehaviour
{
    public static GeneralSingleton generalSingleton;
    public int[] _num = new int[5];
    public int CaseValue, _kingdomIndex;
    public bool isNewGame, isLoadGame, isMyProfile, endQuest, wasEndQuest, isFirtsTime, wasFirtsTime, isBtnNotify, iscloseInfo;
    void Awake()
    {
        Singleton();
        MouseUnLock();
        CaseValue = -1;
        SaveAndLoadManager.LoadSingleton();
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
    public void MouseLockRotate()
    {
        SetCursorState(false, CursorLockMode.None);
    }
    public void MouseLock()
    {
        SetCursorState(false, CursorLockMode.Locked);
    }
    public void MouseUnLock()
    {
        SetCursorState(true, CursorLockMode.None);
    }
    void SetCursorState(bool _bool, CursorLockMode Mode)
    {
        Cursor.visible = _bool;
        Cursor.lockState = Mode;
    }
}