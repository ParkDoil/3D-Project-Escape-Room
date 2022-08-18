using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HintScore : MonoBehaviour
{
    private TextMeshProUGUI _ui;

    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(int score, int totalScore)
    {
        _ui.text = $"��Ʈ ȹ�� ����\n{score} / {totalScore}";
    }
}
