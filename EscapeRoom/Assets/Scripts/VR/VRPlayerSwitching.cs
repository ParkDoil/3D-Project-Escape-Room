using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static OVRInput;

public class VRPlayerSwitching : MonoBehaviour
{
    VRPlayerInteraction _interaction;

    [SerializeField] GameObject[] FirstQuizCams;
    [SerializeField] GameObject LocalPosition;

    [Space(20f)]
    public UnityEvent CameraChange = new UnityEvent();

    public bool CameraSwitching { get; private set; }
    public bool Oneshot { get; private set; }
    public bool CanChange { get; private set; }


    void Start()
    {
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
        for (int i = 0; i < FirstQuizCams.Length; ++i)
        {
            FirstQuizCams[i].transform.localPosition = LocalPosition.transform.localPosition;
        }

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
                ChangingCullingMask();

                UIManager.Instance.SettingUnique();
                UIManager.Instance.ShowFuseUI();
                GameManager.Instance.IsDoorActive = true;
                GameManager.Instance.DoorActive();
            }
            else
            {
                ChangingCullingMask();
                UIManager.Instance.SettingNomal();
                UIManager.Instance.ExitFuseUI();
                GameManager.Instance.IsDoorActive = false;
                GameManager.Instance.DoorActive();
            }
        }
    }

    void ChangingCullingMask()
    {
        if (CameraSwitching == true)
        {
            for (int i = 0; i < FirstQuizCams.Length; ++i)
            {
                Camera _cam = FirstQuizCams[i].GetComponent<Camera>();
                _cam.cullingMask = -1;
                _cam.cullingMask = ~(1 << LayerMask.NameToLayer("FirstQuiz"));
                _cam.cullingMask = ~(1 << LayerMask.NameToLayer("Camera"));
                _cam.cullingMask = ~(1 << LayerMask.NameToLayer("Player"));
            }
        }
        else
        {
            for (int i = 0; i < FirstQuizCams.Length; ++i)
            {
                Camera _cam = FirstQuizCams[i].GetComponent<Camera>();
                _cam.cullingMask = -1;
                _cam.cullingMask = ~(1 << LayerMask.NameToLayer("SecondQuiz"));
                _cam.cullingMask = ~(1 << LayerMask.NameToLayer("CantSee"));
                _cam.cullingMask = ~(1 << LayerMask.NameToLayer("Camera"));
                _cam.cullingMask = ~(1 << LayerMask.NameToLayer("Player"));
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
