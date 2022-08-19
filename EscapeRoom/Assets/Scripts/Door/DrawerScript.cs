using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerScript : MonoBehaviour
{
    public bool Open { get; set; }
    private float _doorOpenPosition = 0.45f;
    private float _moveSpeed = 2f;

    Vector3 _dirVec;
    Vector3 _earlyVec;

    public void ChangeDoorState()
    {
        Open = !Open;
    }
    void Awake()
    {
        _earlyVec = Vector3.zero;
        _dirVec = new Vector3(0f, 0f, _doorOpenPosition);
    }

    void Update()
    {
        if (Open)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition,_dirVec, _moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _earlyVec, _moveSpeed * Time.deltaTime);
        }
    }
}