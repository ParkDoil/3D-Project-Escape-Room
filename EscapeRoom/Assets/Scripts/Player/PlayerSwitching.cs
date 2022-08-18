using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitching : MonoBehaviour
{
    PlayerInteraction _interaction;

    public GameObject BasicCamera;
    public GameObject UniqueCamera;

    public bool CameraSwitching { get; private set; }
    void Start()
    {
        CameraSwitching = false;
        _interaction = GetComponent<PlayerInteraction>();
    }

    void Update()
    {
        if (_interaction.GetFinalObject == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CameraSwitching = !CameraSwitching;
            }
        }

        if (CameraSwitching == true)
        {
            BasicCamera.SetActive(false);
            UniqueCamera.SetActive(true);
            UIManager.Instance.SettingUnique();
        }
        else
        {
            BasicCamera.SetActive(true);
            UniqueCamera.SetActive(false);
            UIManager.Instance.SettingNomal();
        }
    }
}
