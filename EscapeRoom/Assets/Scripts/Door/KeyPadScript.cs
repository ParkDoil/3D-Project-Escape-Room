using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPadScript : MonoBehaviour
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

        GameManager.Instance.KeyPadClear.RemoveListener(Clear);
        GameManager.Instance.KeyPadClear.AddListener(Clear);

        GameManager.Instance.InputKeyPad.RemoveListener(PushButton);
        GameManager.Instance.InputKeyPad.AddListener(PushButton);
    }

    void Update()
    {
        
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
                GameManager.Instance.PasswordCorrect();
            }
            else
            {
                Clear();
                GameManager.Instance.PasswordIncorrect();
            }
        }
    }

    void OnDisable()
    {
        GameManager.Instance.KeyPadClear.RemoveListener(Clear);
        GameManager.Instance.InputKeyPad.RemoveListener(PushButton);
    }
}
