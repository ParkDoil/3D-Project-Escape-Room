using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static OVRInput;

public class VRPlayerMovement : MonoBehaviour
{
    VRPlayerInput _input;
    Rigidbody _rigid;

    public float MoveSpeed = 8f;
    public float RotationSpeed = 120f;
    public float TurnSpeed = 13f;

    private Vector3 dir = Vector3.zero;
    private Vector2 Turndir = Vector2.zero;

    public bool Iscollision { get; private set; }
    public bool CanMove { get; private set; }

    void Awake()
    {
        CanMove = true;
        _input = GetComponent<VRPlayerInput>();
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
            Turndir = _input.ThumStick;

            if (dir != Vector3.zero)
            {
                Move(dir);
            }

            if(Turndir != Vector2.zero)
            {
                TurnAround(Turndir);
            }
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

    void TurnAround(Vector2 TurnVec)
    {
        if (TurnVec.x < 0)
        {
            transform.Rotate(0f, TurnVec.x * Time.deltaTime * RotationSpeed, 0f);
        }
        else if(TurnVec.x > 0)
        {
            transform.Rotate(0f, TurnVec.x * Time.deltaTime * RotationSpeed, 0f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Wall")
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
