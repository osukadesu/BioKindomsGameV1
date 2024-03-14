using UnityEngine;
public class Rotate3Dv2 : MonoBehaviour
{
    [SerializeField] float speed = 300f;
    void OnMouseDrag()
    {
        float x = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
        transform.Rotate(Vector3.up, -x);
    }
}