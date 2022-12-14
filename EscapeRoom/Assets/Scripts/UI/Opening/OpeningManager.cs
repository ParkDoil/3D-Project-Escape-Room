using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static OVRInput;

public class OpeningManager : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.Q) || OVRInput.GetDown(OVRInput.Button.One))
        {
            RealPanel.SetActive(true);
        }
    }

    public void ShowHowToPlay()
    {
        HowToPlay.SetActive(true);
    }

    public void ExitHowToPlay()
    {
        HowToPlay.SetActive(false);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
