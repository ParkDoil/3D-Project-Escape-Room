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

    private int _inputNum = 0;
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

}
