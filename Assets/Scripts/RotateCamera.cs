using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    
    public Vector3 rotationAxis = Vector3.left;
    public int RotationSpeed = 50;
    void Update()
    {
        float verticalSpeed = Input.GetAxis("Vertical");
        Debug.Log(Input.GetAxis("Vertical"));
        if (transform.localEulerAngles.x <= 45 || transform.localEulerAngles.x >=315) {
            transform.Rotate(rotationAxis.normalized * RotationSpeed * Time.deltaTime * -verticalSpeed);
        }else if (transform.localEulerAngles.x > 45 && verticalSpeed < 0 && transform.localEulerAngles.x < 46)
        {
            transform.Rotate(rotationAxis.normalized * RotationSpeed * Time.deltaTime * -verticalSpeed);
        }
        else if(transform.localEulerAngles.x < 315 && verticalSpeed > 0 && transform.localEulerAngles.x > 314)
        {
            transform.Rotate(rotationAxis.normalized * RotationSpeed * Time.deltaTime * -verticalSpeed);
        }
        Debug.Log(transform.localEulerAngles.x);
    }
}



