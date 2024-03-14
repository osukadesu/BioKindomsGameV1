using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour
{
    [SerializeField] Transform target;
    void Update()
    {
        transform.position = target.transform.position + new Vector3(0, 25, -24);
    }
}