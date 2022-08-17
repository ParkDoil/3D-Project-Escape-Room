using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoorScript : MonoBehaviour
{
    public bool Open { get; set; }
    private float _doorOpenAngle = 100f;
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
            Quaternion targetRotation = Quaternion.Euler(0, _doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotation2 = Quaternion.Euler(0, _doorCloseAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation2, _rotationSpeed * Time.deltaTime);
        }
    }
}
