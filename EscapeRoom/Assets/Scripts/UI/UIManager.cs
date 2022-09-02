using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : SingletonBehaviour<UIManager>
{
    [Header ("카메라 안에 존재해야하는  UI")]
    [SerializeField] GameObject InteractionUI;
    [SerializeField] GameObject FinalHintUI;
    [SerializeField] GameObject ShowAgainUI;
    [SerializeField] GameObject CameraSettingUI;
    [SerializeField] GameObject HintUI;
    [SerializeField] GameObject FuseUI;

    [Space (10f)]
    [SerializeField] GameObject FuseImage;
    [SerializeField] GameObject ScrollImage;

    [Space(10f)]
    [SerializeField] GameObject[] BedTextUI;
    [SerializeField] GameObject[] SofaTextUI;
    [SerializeField] GameObject[] LockDoorUI;
    [SerializeField] GameObject[] LaptopUI;

    [Header ("월드스페이스 공간에 따로 있어야하는 UI")]
    [SerializeField] GameObject KeyPadUI;
    [SerializeField] GameObject MenuUI;
    [SerializeField] GameObject SupplyPanel;
    [SerializeField] GameObject SwitchBoardUI;
    [SerializeField] GameObject LockComputerUI;
    [SerializeField] GameObject UnlockComputerUI;

    [Header ("일시정지 메뉴창 위치")]
    [SerializeField] GameObject MenuUIPosition;

    [Space (20f)]
    [Header ("이벤트")]
    public UnityEvent ChangeNormal = new UnityEvent();
    public UnityEvent ChangeUnique = new UnityEvent();
    public UnityEvent FixFuse = new UnityEvent();
    public UnityEvent Blink = new UnityEvent();
    public UnityEvent UIOpen = new UnityEvent();
    public UnityEvent UIClose = new UnityEvent();

    private float _prevScrollFillAmount;
    private float _prevFuseFillAmount;

    private GameObject _scrollFrame;
    private GameObject _fuseFrame;


    public bool IsPossibleInteraction { get; private set; }

    private void Start()
    {
        IsPossibleInteraction = true;
        _scrollFrame = ScrollImage.transform.GetChild(0).gameObject;
        _fuseFrame = FuseImage.transform.GetChild(0).gameObject;

        _scrollFrame.SetActive(false);
        _fuseFrame.SetActive(false);
    }

    public void OnInteractionUI()
    {
        InteractionUI.SetActive(true);
    }
    public void OffInteractionUI()
    {
        InteractionUI.SetActive(false);
    }

    public void ShowFinalHintText()
    {
        ShowAgainUI.SetActive(false);
        FinalHintUI.SetActive(true);
    }
    public void ExitFinalHintText()
    {
        ShowAgainUI.SetActive(true);
        FinalHintUI.SetActive(false);
    }

    public void DeleteFinalHintText()
    {
        ShowAgainUI.SetActive(false);
        FinalHintUI.SetActive(false);
    }

    public void ShowBedText()
    {
        IsPossibleInteraction = false;
        for (int i = 0; i < BedTextUI.Length; ++i)
        {
            BedTextUI[i].SetActive(false);
        }

        int index = Random.Range(0, BedTextUI.Length);

        BedTextUI[index].SetActive(true);

        Invoke("UnshowBedText", 0.7f);
    }
    public void UnshowBedText()
    {
        IsPossibleInteraction = true;
        for (int i = 0; i < BedTextUI.Length; ++i)
        {
            BedTextUI[i].SetActive(false);
        }
    }

    public void ShowSofaText()
    {
        IsPossibleInteraction = false;
        for (int i = 0; i < SofaTextUI.Length; ++i)
        {
            SofaTextUI[i].SetActive(false);
        }

        int index = Random.Range(0, SofaTextUI.Length);

        SofaTextUI[index].SetActive(true);

        Invoke("UnshowSofaText", 0.7f);
    }
    public void UnshowSofaText()
    {
        IsPossibleInteraction = true;
        for (int i = 0; i < SofaTextUI.Length; ++i)
        {
            SofaTextUI[i].SetActive(false);
        }
    }
    public void ShowLaptopText()
    {
        IsPossibleInteraction = false;
        for (int i = 0; i < LaptopUI.Length; ++i)
        {
            LaptopUI[i].SetActive(false);
        }

        int index = Random.Range(0, LaptopUI.Length);

        LaptopUI[index].SetActive(true);

        Invoke("UnshowLaptopText", 0.7f);
    }
    public void UnshowLaptopText()
    {
        IsPossibleInteraction = true;
        for (int i = 0; i < LaptopUI.Length; ++i)
        {
            LaptopUI[i].SetActive(false);
        }
    }

    public void ShowLockDoorText()
    {
        IsPossibleInteraction = false;
        for (int i = 0; i < LockDoorUI.Length; ++i)
        {
            LockDoorUI[i].SetActive(false);
        }

        int index = Random.Range(0, LockDoorUI.Length);

        LockDoorUI[index].SetActive(true);

        Invoke("UnshowLockDoorText", 0.7f);
    }
    public void UnshowLockDoorText()
    {
        IsPossibleInteraction = true;
        for (int i = 0; i < LockDoorUI.Length; ++i)
        {
            LockDoorUI[i].SetActive(false);
        }
    }

    public void ShowCameraUI()
    {
        CameraSettingUI.SetActive(true);
    }

    public void SettingNomal()
    {
        ChangeNormal.Invoke();
    }

    public void SettingUnique()
    {
        ChangeUnique.Invoke();
    }

    public void ShowKeyPad()
    {
        KeyPadUI.SetActive(true);
        UIOpen.Invoke();
        Time.timeScale = 0f;
    }

    public void ExitKeyPad()
    {
        GameManager.Instance.ClearPassword();
        KeyPadUI.SetActive(false);
        UIClose.Invoke();
        Time.timeScale = 1f;
    }

    public void ShowMenu()
    {
        Time.timeScale = 0f;
        UIOpen.Invoke();
        MenuUI.transform.position = MenuUIPosition.transform.position;
        MenuUI.transform.rotation = MenuUIPosition.GetComponentInParent<Transform>().rotation;
        MenuUI.SetActive(true);
    }
    public void ExitMenu()
    {
        Time.timeScale = 1f;
        UIClose.Invoke();
        MenuUI.SetActive(false);
    }

    public void ShowFuseUI()
    {
        _prevScrollFillAmount = ScrollImage.GetComponent<Image>().fillAmount;
        ScrollImage.GetComponent<Image>().fillAmount = 0f;
        FuseUI.SetActive(true);
        HintUI.SetActive(false);
        FuseImage.GetComponent<Image>().fillAmount = _prevFuseFillAmount;

        CheakFillAmount();
    }
    public void ExitFuseUI()
    {
        _prevFuseFillAmount = FuseImage.GetComponent<Image>().fillAmount;
        FuseImage.GetComponent<Image>().fillAmount = 0f;
        FuseUI.SetActive(false);
        HintUI.SetActive(true);
        ScrollImage.GetComponent<Image>().fillAmount = _prevScrollFillAmount;

        CheakFillAmount();
    }

    public void IncreaseHintImage(float _scrollImage)
    {
        ScrollImage.GetComponent<Image>().fillAmount += _scrollImage;
        CheakFillAmount();
    }
    public void IncreaseFuseImage(float _fuseImage)
    {
        FuseImage.GetComponent<Image>().fillAmount += _fuseImage;
        CheakFillAmount();
    }

    public void CheakFillAmount()
    {
        if (ScrollImage.GetComponent<Image>().fillAmount >= 1f)
        {
            _scrollFrame.SetActive(true);
        }
        else
        {
            _scrollFrame.SetActive(false);
        }

        if (FuseImage.GetComponent<Image>().fillAmount >= 1f)
        {
            _fuseFrame.SetActive(true);
        }
        else
        {
            _fuseFrame.SetActive(false);
        }
    }

    public void FixSupply()
    {
        FixFuse.Invoke();
    }

    public void ShowSupplyPanel()
    {
        SupplyPanel.SetActive(true);
        UIOpen.Invoke();
        Time.timeScale = 0f;
    }
    public void ExitSupplyPanel()
    {
        UIClose.Invoke();
        SupplyPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowSwitchBoard()
    {
        SwitchBoardUI.SetActive(true);
        UIOpen.Invoke();
        Time.timeScale = 0f;
    }
    public void ExitSwitchBoard()
    {
        SwitchBoardUI.SetActive(false);
        UIClose.Invoke();
        Time.timeScale = 1f;
    }

    public void ShowLockComputerUI()
    {
        LockComputerUI.SetActive(true);
        UIOpen.Invoke();
        Time.timeScale = 0f;
    }

    public void ExitLockComputerUI()
    {
        GameManager.Instance.ClearNumPad();
        LockComputerUI.SetActive(false);
        UIClose.Invoke();
        Time.timeScale = 1f;
    }

    public void ShowUnlockComputerUI()
    {
        UnlockComputerUI.SetActive(true);
        UIOpen.Invoke();
        Time.timeScale = 0f;
    }
    public void ExitUnlockComputerUI()
    {
        UnlockComputerUI.SetActive(false);
        UIClose.Invoke();
        Time.timeScale = 1f;
    }
    
    public void ModeChange()
    {
        Blink.Invoke();
    }
}
