using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayCube : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up;
    public Vector3 rotationAxis2 = Vector3.left;
    public int RotationSpeed = 50;
    void Update()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        transform.Rotate(rotationAxis.normalized * RotationSpeed * Time.deltaTime * -horizontalSpeed);
    }
}


