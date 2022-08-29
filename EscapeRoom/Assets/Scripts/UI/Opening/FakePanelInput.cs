using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakePanelInput : MonoBehaviour
{
    public GameObject RealPanel;
    public GameObject HowToPlay;

    void Start()
    {
        RealPanel.SetActive(false);
        HowToPlay.SetActive(false);
    }

    void Update()
    {
        Debug.Log("������Ʈ�Լ� ���ư����");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("QŰ �ԷµǾ���");
            RealPanel.SetActive(true);
        }
    }
}