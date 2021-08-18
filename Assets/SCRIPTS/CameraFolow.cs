using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    public Transform target;

    public Vector3 Ofset;

    private void Update()
    {
        transform.LookAt(target);

        transform.position = target.position + Ofset;
    }
}
