using UnityEngine;
public class MouseController : MonoBehaviour
{
    public void MouseLock()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void MouseUnLock()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}