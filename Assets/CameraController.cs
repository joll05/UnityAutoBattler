using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public float smoothTime = 1.0f;

    Vector3 smoothDampVelocity = Vector3.zero;

    void LateUpdate()
    {
        transform.position = Vector3.SmoothDamp(transform.position, target.position, ref smoothDampVelocity, smoothTime);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }
}
