using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIManager : SingletonBehaviour<UIManager>
{
    public GameObject InteractionUI;
    public GameObject FinalHintUI;
    public GameObject ShowAgainUI;
    public GameObject CameraSettingUI;

    public GameObject[] BedTextUI;
    public GameObject[] SofaTextUI;

    public UnityEvent ChangeNormal = new UnityEvent();
    public UnityEvent ChangeUnique = new UnityEvent();

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
        for (int i = 0; i < BedTextUI.Length; ++i)
        {
            BedTextUI[i].SetActive(false);
        }

        int index = Random.Range(0, BedTextUI.Length);

        BedTextUI[index].SetActive(true);

        Invoke("UnshowBedText", 1.2f);
    }
    public void UnshowBedText()
    {
        for (int i = 0; i < BedTextUI.Length; ++i)
        {
            BedTextUI[i].SetActive(false);
        }
    }

    public void ShowSofaText()
    {
        for (int i = 0; i < SofaTextUI.Length; ++i)
        {
            SofaTextUI[i].SetActive(false);
        }

        int index = Random.Range(0, SofaTextUI.Length);

        SofaTextUI[index].SetActive(true);

        Invoke("UnshowSofaText", 1.2f);
    }
    public void UnshowSofaText()
    {
        for (int i = 0; i < SofaTextUI.Length; ++i)
        {
            SofaTextUI[i].SetActive(false);
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
}
