using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerNumpad : MonoBehaviour
{
    private int[] _answer = new int[4];
    private int[] _input = new int[4];
    private int _index;

    void Start()
    {
        _answer[0] = 4;
        _answer[1] = 3;
        _answer[2] = 5;
        _answer[3] = 8;
    }

    void OnEnable()
    {
        GameManager.Instance.InputNumPad.RemoveListener(PushButton);
        GameManager.Instance.InputNumPad.AddListener(PushButton);

        GameManager.Instance.NumPadClear.RemoveListener(Clear);
        GameManager.Instance.NumPadClear.AddListener(Clear);
    }

    void Clear()
    {
        _index = 0;
    }

    void PushButton(int _inputNum)
    {
        _input[_index] = _inputNum;
        ++_index;

        if (_index == 4)
        {
            int _correctCount = 0;

            for (int i = 0; i < 4; ++i)
            {
                if (_answer[i] == _input[i])
                {
                    ++_correctCount;
                }
            }

            if (_correctCount == 4)
            {
                UIManager.Instance.ExitLockComputerUI();
                GameManager.Instance.ComputerPasswordCorrect();
            }
            else
            {
                Clear();
                UIManager.Instance.ExitLockComputerUI();
            }
        }
    }

    void OnDisable()
    {
        GameManager.Instance.InputNumPad.RemoveListener(PushButton);
    }
}
