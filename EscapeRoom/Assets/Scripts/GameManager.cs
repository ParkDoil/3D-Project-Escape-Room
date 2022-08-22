using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public UnityEvent DoorUnlock = new UnityEvent();
    public UnityEvent DoorLock = new UnityEvent();
    public UnityEvent KeyPadClear = new UnityEvent();
    public UnityEvent<int> InputKeyPad = new UnityEvent<int>();
    public UnityEvent ChangeMode = new UnityEvent();

    public GameObject HiddenWall;
    public GameObject FirstQuiz;
    public GameObject SecondQuiz;

    private int _inputNum = 0;

    public bool IsDoorActive { get; set; }
    public int InputNum
    {
        get
        {
            return _inputNum;
        }
        set
        {
            _inputNum = value;
            InputKeyPad.Invoke(_inputNum);
        }
    }

    public void PushKeyPad(int _inputNum)
    {
        InputNum = _inputNum;
    }

    public void PasswordCorrect()
    {
        DoorUnlock.Invoke();
    }
    public void PasswordIncorrect()
    {
        DoorLock.Invoke();
    }

    public void ClearPassword()
    {
        KeyPadClear.Invoke();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void DoorActive()
    {
        if (IsDoorActive == true)
        {
            HiddenWall.SetActive(false);
            FirstQuiz.SetActive(false);
            SecondQuiz.SetActive(true);
        }
        else
        {
            HiddenWall.SetActive(true);
            FirstQuiz.SetActive(true);
            SecondQuiz.SetActive(false);
        }
    }

    public void ModeChange()
    {
        ChangeMode.Invoke();
    }

}
