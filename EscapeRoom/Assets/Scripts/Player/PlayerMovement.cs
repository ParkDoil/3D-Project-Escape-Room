using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput _input;
    Rigidbody _rigid;

    public float MoveSpeed = 10f;
    public float RotationSpeed = 120f;
    public float TurnSpeed = 8.0f;

    private float _xRotate = 0.0f;

    Vector3 dir = Vector3.zero;

    void Awake()
    {
        _input = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        dir.x = _input.X;
        dir.z = _input.Z;

        if(dir != Vector3.zero)
        {
            //transform.forward = dir;
            Move(dir);
        }

        Show();
    }

    /// <summary>
    /// ĳ���͸� �����δ�.
    /// </summary>
    /// <param name="direction">����� ĳ������ forward ������ �ǹ��ϸ�, ������ ĳ������ backward ������ �ǹ��Ѵ�.</param>
    void Move(Vector3 direction)
    {
        Vector3 deltaPosition = MoveSpeed * direction * Time.deltaTime;
        Vector3 newPosition = _rigid.position + deltaPosition;
        _rigid.MovePosition(newPosition);
    }

    void Show()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * TurnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * TurnSpeed;
        _xRotate = Mathf.Clamp(_xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(_xRotate, yRotate, 0);
    }
}
