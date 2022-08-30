using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayButton : MonoBehaviour
{
    public GameObject HowToPlay;

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
