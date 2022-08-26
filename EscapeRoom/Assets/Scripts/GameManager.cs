using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : SingletonBehaviour<GameManager>
{
    public UnityEvent DoorUnlock = new UnityEvent();
    public UnityEvent DoorLock = new UnityEvent();
    public UnityEvent ComputerUnlock = new UnityEvent();
    public UnityEvent KeyPadClear = new UnityEvent();
    public UnityEvent NumPadClear = new UnityEvent();
    public UnityEvent<int> InputKeyPad = new UnityEvent<int>();
    public UnityEvent<int> InputNumPad = new UnityEvent<int>();
    public UnityEvent ChangeMode = new UnityEvent();
    public UnityEvent Positive = new UnityEvent();
    public UnityEvent Negative = new UnityEvent();
    public UnityEvent StopMove = new UnityEvent();
    public UnityEvent ContinueMove = new UnityEvent();

    public GameObject HiddenWall;
    public GameObject FirstQuiz;
    public GameObject SecondQuiz;
    public GameObject PasswordHint;

    private int _inputNum = 0;
    private int _inputPassword = 0;

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

    public int InputPassword
    {
        get
        {
            return _inputPassword;
        }
        set
        {
            _inputPassword = value;
            InputNumPad.Invoke(_inputPassword);
        }
    }

    public void PushKeyPad(int _inputNum)
    {
        InputNum = _inputNum;
    }

    public void PushPassword(int _inputNumPad)
    {
        InputPassword = _inputNumPad;
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

    public void ComputerPasswordCorrect()
    {
        ComputerUnlock.Invoke();
    }

    public void ClearNumPad()
    {
        NumPadClear.Invoke();
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

    public void ElectricitySupply(bool isOn)
    {
        if (isOn == true)
        {
            Positive.Invoke();
        }
        else
        {
            Negative.Invoke();
        }
    }

    public void TurnOnProjector()
    {
        PasswordHint.SetActive(true);
    }
    public void TurnOffProjector()
    {
        PasswordHint.SetActive(false);
    }

    public void PlayerStop()
    {
        StopMove.Invoke();
    }

    public void PlayerMove()
    {
        ContinueMove.Invoke();
    }
}
