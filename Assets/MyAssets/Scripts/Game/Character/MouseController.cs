using UnityEngine;
public class MouseController : MonoBehaviour
{
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