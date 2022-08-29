using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    private Image _ui;
    private float _fadeCount;

    void Awake()
    {
        _ui = GetComponent<Image>();
        _fadeCount = 1f;
    }
    void OnEnable()
    {
        UIManager.Instance.Blink.RemoveListener(Blinking);
        UIManager.Instance.Blink.AddListener(Blinking);
    }

    void Blinking()
    {
        GameManager.Instance.PlayerStop();
        StopAllCoroutines();
        _fadeCount = 1f;
        _ui.color = new Color(0f, 0f, 0f, _fadeCount);
        StartCoroutine(ObjectBlink());
    }

    IEnumerator ObjectBlink()
    {
        while (_fadeCount > 0f)
        {
            _fadeCount -= 0.05f;
            yield return new WaitForSeconds(0.05f);
            _ui.color = new Color(0f, 0f, 0f, _fadeCount);
        }

        GameManager.Instance.PlayerMove();
    }

    //void OnDisable()
    //{
    //    UIManager.Instance.Blink.RemoveListener(Blinking);
    //}
}
