using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera3D : MonoBehaviour
{
    public Transform target;
    public float Speed;
    public Vector3 offset;
    
    void Update()
    {
        transform.position = target.position + offset;
    }
}
