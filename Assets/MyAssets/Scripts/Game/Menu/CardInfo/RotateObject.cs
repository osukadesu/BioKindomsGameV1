using Unity.VisualScripting;
using UnityEngine;
public class RotateObject : MonoBehaviour
{
    [SerializeField] float speed = 300f;
    void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
        float y = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, -x);
        transform.Rotate(Vector3.right, -y);
    }
}