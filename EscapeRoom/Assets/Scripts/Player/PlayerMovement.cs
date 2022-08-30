using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput _input;
    Rigidbody _rigid;

    public float MoveSpeed = 8f;
    public float RotationSpeed = 120f;
    public float TurnSpeed = 13f;

    private float _xRotate = 0.0f;

    Vector3 dir = Vector3.zero;

    public bool Iscollision { get; private set; }
    public bool CanMove { get; private set; }

    void Awake()
    {
        CanMove = true;
        _input = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        GameManager.Instance.StopMove.RemoveListener(DontMove);
        GameManager.Instance.ContinueMove.RemoveListener(DoMove);

        GameManager.Instance.StopMove.AddListener(DontMove);
        GameManager.Instance.ContinueMove.AddListener(DoMove);
    }

    void FixedUpdate()
    {
        if (CanMove == true)
        {
            dir.x = _input.X;
            dir.z = _input.Z;

            if (dir != Vector3.zero)
            {
                Move(dir);
            }

            Look();
        }
    }

    void Move(Vector3 direction)
    {
        Vector3 ForwardPosition = MoveSpeed * Time.deltaTime * direction.z * transform.forward;
        Vector3 SidePosition = MoveSpeed * Time.deltaTime * direction.x * transform.right;
        Vector3 newPosition = _rigid.position + ForwardPosition + SidePosition;

        if (Iscollision == true)
        {
            _rigid.velocity = Vector3.zero;
        }

        _rigid.MovePosition(newPosition);

    }

    void Look()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * TurnSpeed;
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * TurnSpeed;
        _xRotate = Mathf.Clamp(_xRotate + xRotateSize, -45, 80);

        transform.eulerAngles = new Vector3(_xRotate, yRotate, 0);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Wall")
        {
            Iscollision = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Wall")
        {
            Iscollision = false;
        }
    }

    void DontMove()
    {
        CanMove = false;
    }
    
    void DoMove()
    {
        CanMove = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            SceneManager.LoadScene(2);
        }
    }
}
