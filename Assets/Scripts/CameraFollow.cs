using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 cameraOffset = new Vector3(0f, 1.3f, -3f);
    private Transform target;

     void Start() 
    {
        target = GameObject.Find("Player").transform;
    }

    void LateUpdate() 
    {
        transform.position = target.TransformPoint(cameraOffset);
        transform.LookAt(target);
    }
    
}
