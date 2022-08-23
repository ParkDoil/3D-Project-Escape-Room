using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitching : MonoBehaviour
{
    PlayerInteraction _interaction;

    public GameObject BasicCamera;
    public GameObject UniqueCamera;

    public bool CameraSwitching { get; private set; }
    public bool Oneshot { get; private set; }
    void Start()
    {
        CameraSwitching = false;
        _interaction = GetComponent<PlayerInteraction>();
    }

    void Update()
    {
        Oneshot = false;
        if (_interaction.GetSwitchObject == true)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Oneshot = true;
                CameraSwitching = !CameraSwitching;
                GameManager.Instance.ModeChange();
            }
        }

        if (Oneshot == true)
        {
            if (CameraSwitching == true)
            {
                BasicCamera.SetActive(false);
                UniqueCamera.SetActive(true);
                UIManager.Instance.SettingUnique();
                UIManager.Instance.ShowFuseUI();
                GameManager.Instance.IsDoorActive = true;
                GameManager.Instance.DoorActive();
            }
            else
            {
                BasicCamera.SetActive(true);
                UniqueCamera.SetActive(false);
                UIManager.Instance.SettingNomal();
                UIManager.Instance.ExitFuseUI();
                GameManager.Instance.IsDoorActive = false;
                GameManager.Instance.DoorActive();
            }
        }
    }
}
