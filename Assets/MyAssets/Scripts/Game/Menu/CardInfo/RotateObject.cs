using UnityEngine;
public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 350f;
    private Vector3 _currentRotation;
    private void Start()
    {
        _currentRotation = transform.rotation.eulerAngles;
    }
    void OnMouseDrag()
    {
        GeneralSingleton.generalSingleton.MouseLockRotate();
        float rotX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float rotY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;
        _currentRotation.y -= rotX;
        _currentRotation.x -= rotY;
        Quaternion targetRotation = Quaternion.Euler(_currentRotation);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
    }
    void OnMouseUp()
    {
        GeneralSingleton.generalSingleton.MouseUnLock();
    }
}