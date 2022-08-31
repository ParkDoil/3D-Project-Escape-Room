using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class VRPlayerSwitching : MonoBehaviour
{
    VRPlayerInteraction _interaction;

    public GameObject MainFirstQuizCamera;
    public GameObject LeftFirstQuizCamera;
    public GameObject RightFirstQuizCamera;

    public GameObject MainSecondQuizCamera;
    public GameObject LeftSecondQuizCamera;
    public GameObject RightSecondQuizCamera;

    public GameObject UI;

    private Canvas UICanvas;

    public bool CameraSwitching { get; private set; }
    public bool Oneshot { get; private set; }
    public bool CanChange { get; private set; }
    void Start()
    {
        UICanvas = UI.GetComponent<Canvas>();
        UICanvas.worldCamera = MainFirstQuizCamera.GetComponent<Camera>();
        CanChange = true;
        CameraSwitching = false;
        _interaction = GetComponent<VRPlayerInteraction>();
    }

    void OnEnable()
    {
        UIManager.Instance.UIOpen.RemoveListener(UIOpenStatus);
        UIManager.Instance.UIOpen.AddListener(UIOpenStatus);

        UIManager.Instance.UIClose.RemoveListener(UICloseStatus);
        UIManager.Instance.UIClose.AddListener(UICloseStatus);

    }

    void Update()
    {
        Oneshot = false;
        if (_interaction.GetSwitchObject == true)
        {
            if (OVRInput.GetDown(OVRInput.Button.Two))
            {
                if (CanChange == true)
                {
                    Oneshot = true;
                    CameraSwitching = !CameraSwitching;
                    GameManager.Instance.ModeChange();
                    UIManager.Instance.ModeChange();
                }
            }
        }

        if (Oneshot == true)
        {
            if (CameraSwitching == true)
            {
                UICanvas.worldCamera = MainSecondQuizCamera.GetComponent<Camera>();
                MainFirstQuizCamera.SetActive(false);
                MainSecondQuizCamera.SetActive(true);
                UIManager.Instance.SettingUnique();
                UIManager.Instance.ShowFuseUI();
                GameManager.Instance.IsDoorActive = true;
                GameManager.Instance.DoorActive();
            }
            else
            {
                UICanvas.worldCamera = MainFirstQuizCamera.GetComponent<Camera>();
                MainFirstQuizCamera.SetActive(true);
                MainSecondQuizCamera.SetActive(false);
                UIManager.Instance.SettingNomal();
                UIManager.Instance.ExitFuseUI();
                GameManager.Instance.IsDoorActive = false;
                GameManager.Instance.DoorActive();
            }
        }
    }

    void UIOpenStatus()
    {
        CanChange = false;
    }

    void UICloseStatus()
    {
        CanChange = true;
    }

    //void OnDisable()
    //{
    //    UIManager.Instance.UIOpen.RemoveListener(UIOpenStatus);
    //    UIManager.Instance.UIClose.RemoveListener(UICloseStatus);
    //}
}
