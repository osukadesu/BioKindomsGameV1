using UnityEngine;
public class FisherMouse : MonoBehaviour
{
    /*
    [SerializeField] float rotationSpeed = 400f;
    [SerializeField] Vector3 _currentRotation;
    void Start()
    {
        Screen.SetResolution(640, 480, false);
        _currentRotation = transform.rotation.eulerAngles;
    }
    void OnMouseDrag()
    {
        Screen.SetResolution(1920, 1080, true);
        MouseLockRotate();
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float rotZ = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        _currentRotation.y -= rotX;
        _currentRotation.z += rotZ;
        Quaternion targetRotation = Quaternion.Euler(_currentRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    void OnMouseUp()
    {
        Screen.SetResolution(640, 480, false);
        MouseUnLock();
    }
    public void MouseLockRotate() => SetCursorState(false, CursorLockMode.None);
    public void MouseUnLock() => SetCursorState(true, CursorLockMode.None);
    void SetCursorState(bool _bool, CursorLockMode Mode)
    {
        Cursor.visible = _bool;
        Cursor.lockState = Mode;
    }
    */
}