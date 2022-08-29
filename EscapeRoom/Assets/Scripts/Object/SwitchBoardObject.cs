using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBoardObject : MonoBehaviour
{
    public GameObject Lamp;
    public bool IsOnLamp { get; private set; }
    void OnEnable()
    {
        UIManager.Instance.FixFuse.RemoveListener(LampOn);

        UIManager.Instance.FixFuse.AddListener(LampOn);

        Lamp.SetActive(IsOnLamp);
    }

    void LampOn()
    {
        IsOnLamp = true;
        Lamp.SetActive(IsOnLamp);
    }

    void OnDisable()
    {
        UIManager.Instance.FixFuse.RemoveListener(LampOn);
    }
}
