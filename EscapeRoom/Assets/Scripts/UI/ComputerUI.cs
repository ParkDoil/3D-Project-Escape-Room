using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ComputerUI : MonoBehaviour
{
    TextMeshProUGUI _ui;
    public UnityEvent UnLockComputer = new UnityEvent();

    private int _index;

    private string[] _input = new string[4];

    public bool IsCorrect { get; private set; }

    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        SetInit();

        GameManager.Instance.InputNumPad.RemoveListener(UpdatePassword);
        GameManager.Instance.InputNumPad.AddListener(UpdatePassword);
    }

    void UpdatePassword(int _num)
    {
        _input[_index] = "¡Ü";
        ++_index;
        _ui.text = $"{_input[0]}{_input[1]}{_input[2]}{_input[3]}";
    }

    void SetInit()
    {
        _index = 0;

        for (int i = 0; i < 4; ++i)
        {
            _input[i] = "  ";
        }

        _ui.text = $"{_input[0]}{_input[1]}{_input[2]}{_input[3]}";
    }

    void OnDisable()
    {
        GameManager.Instance.InputNumPad.AddListener(UpdatePassword);
    }
}
