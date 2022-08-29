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
        Debug.Log("업데이트함수 돌아간드아");
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("Q키 입력되었음");
            RealPanel.SetActive(true);
        }
    }
}