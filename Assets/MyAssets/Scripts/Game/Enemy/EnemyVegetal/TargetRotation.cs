using UnityEditor.Experimental.GraphView;
using UnityEngine;
public class TargetRotation : MonoBehaviour
{
    [SerializeField] Transform target;
    void Update()
    {
        Vector3 targetOrientation = target.position - transform.position;
        Quaternion quaternion = Quaternion.LookRotation(targetOrientation);
        transform.rotation = Quaternion.Slerp(transform.rotation, quaternion, Time.deltaTime);
    }
}