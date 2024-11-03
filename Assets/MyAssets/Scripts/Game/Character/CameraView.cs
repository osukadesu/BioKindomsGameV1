using UnityEngine;
public class CameraView : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Vector3 distance;
    void Start() 
    {
        distance=transform.position-player.transform.position;
    }
    void Update()
    {
        transform.position = player.transform.position+distance;
    }
}