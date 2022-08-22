using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FuseScore : MonoBehaviour
{
    private TextMeshProUGUI _ui;

    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateText(int score, int totalScore)
    {
        _ui.text = $"Ç»Áî È¹µæ °³¼ö\n{score} / {totalScore}";
    }
}
