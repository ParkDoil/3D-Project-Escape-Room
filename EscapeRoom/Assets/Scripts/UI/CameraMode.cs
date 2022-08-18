using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CameraMode : MonoBehaviour
{
    TextMeshProUGUI _ui;
    void Awake()
    {
        _ui = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        UIManager.Instance.ChangeNormal.RemoveListener(NormalSetting);
        UIManager.Instance.ChangeUnique.RemoveListener(UniqueSetting);

        UIManager.Instance.ChangeNormal.AddListener(NormalSetting);
        UIManager.Instance.ChangeUnique.AddListener(UniqueSetting);
    }

    public void NormalSetting()
    {
        _ui.text = $"카메라 모드\n'일반'";
    }

    public void UniqueSetting()
    {
        _ui.text = $"카메라 모드\n'특수'";
    }

    void OnDisable()
    {
        UIManager.Instance.ChangeNormal.RemoveListener(NormalSetting);
        UIManager.Instance.ChangeUnique.RemoveListener(UniqueSetting);
    }
}
