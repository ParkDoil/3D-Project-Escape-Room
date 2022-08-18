using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownDoorScript : MonoBehaviour
{
    public bool Open { get; set; }
    private float _doorOpenAngle = 65f;
    private float _doorCloseAngle = 0f;
    private float _rotationSpeed = 2f;

    public void ChangeDoorState()
    {
        Open = !Open;
    }

    void Update()
    {
        if (Open)
        {
            Quaternion targetRotation = Quaternion.Euler(_doorOpenAngle, 0f, 0f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(_doorCloseAngle, 0f, 0f);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, _rotationSpeed * Time.deltaTime);
        }
    }
}