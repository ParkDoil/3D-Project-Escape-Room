using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainDoorScript : MonoBehaviour
{
    public bool IsLock { get; private set; }

    void Start()
    {
        IsLock = true;
    }

    void OnEnable()
    {
        GameManager.Instance.DoorUnlock.RemoveListener(OpenDoor);

        GameManager.Instance.DoorUnlock.AddListener(OpenDoor);
    }

    public void OpenDoor()
    {
        IsLock = false;
    }

    //void OnDisable()
    //{
    //    GameManager.Instance.DoorUnlock.RemoveListener(OpenDoor);
    //}
}
