using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : SingletonBehaviour<UIManager>
{

    public GameObject InteractionUI;


    void Start()
    {
        
    }


    void FixedUpdate()
    {
    }

    public void OnInteractionUI()
    {
        InteractionUI.SetActive(true);
    }
    public void OffInteractionUI()
    {
        InteractionUI.SetActive(false);
    }
}
