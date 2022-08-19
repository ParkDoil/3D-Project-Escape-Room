using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPadUI : MonoBehaviour
{
    TextMeshProUGUI _ui;

    private int _index;

    private string[] _input = new string[4];

    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        SetInit();

        GameManager.Instance.InputKeyPad.RemoveListener(UpdatePad);
        GameManager.Instance.InputKeyPad.AddListener(UpdatePad);

        GameManager.Instance.DoorLock.RemoveListener(ChangeIncorrect);
        GameManager.Instance.DoorLock.AddListener(ChangeIncorrect);

        GameManager.Instance.DoorUnlock.RemoveListener(ChangeCorrect);
        GameManager.Instance.DoorUnlock.AddListener(ChangeCorrect);
    }
    void PrintInit()
    {
        _ui.text = $"{_input[0]}{_input[1]}{_input[2]}{_input[3]}";
    }

    void UpdatePad(int _num)
    {
        _input[_index] = _num.ToString();
        ++_index;
        _ui.text = $"{_input[0]}{_input[1]}{_input[2]}{_input[3]}";
    }

    void ChangeCorrect()
    {
        _ui.text = $"Correct";
        _index = 0;

        
    }

    void ChangeIncorrect()
    {
        _ui.text = "Incorrect";
        StartCoroutine(Correct());
    }

    void SetInit()
    {
        _index = 0;

        for (int i = 0; i < 4; ++i)
        {
            _input[i] = "_";
        }
        PrintInit();
    }

    void OnDisable()
    {
        GameManager.Instance.InputKeyPad.RemoveListener(UpdatePad);
        GameManager.Instance.DoorLock.RemoveListener(ChangeIncorrect);
        GameManager.Instance.DoorUnlock.RemoveListener(ChangeCorrect);
        StopAllCoroutines();
    }

    IEnumerator Correct()
    {
        yield return new WaitForSecondsRealtime(1f);
        SetInit();
    }
}
