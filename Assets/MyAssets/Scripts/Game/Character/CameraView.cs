using UnityEngine;
public class CameraView : MonoBehaviour
{
    [SerializeField] Transform target;
    void Update()
    {
        transform.position = target.transform.position + new Vector3(40f, 21f, 4f);
    }
}