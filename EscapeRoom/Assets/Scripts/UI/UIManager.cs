using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBehaviour<UIManager>
{
    public GameObject InteractionUI;
    public GameObject FinalHintUI;
    public GameObject ShowAgainUI;

    public void OnDoorInteractionUI()
    {
        InteractionUI.SetActive(true);
    }
    public void OffDoorInteractionUI()
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
}
