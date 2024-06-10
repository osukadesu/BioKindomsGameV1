using UnityEngine;
public class CameraView : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;

    void LateUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}