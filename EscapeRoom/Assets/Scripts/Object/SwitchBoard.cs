using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchBoard : MonoBehaviour
{
    public GameObject RelatedRight;

    Slider _slider;

    public bool IsOn { get; private set; }

    void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    public void ChangingStatus()
    {
        if (_slider.value == _slider.maxValue)
        {
            IsOn = true;
            RelatedRight.GetComponent<Image>().color = new Color(0f, 255f, 0f, 255f);
            GameManager.Instance.ElectricitySupply(IsOn);
        }
        else
        {
            IsOn = false;
            RelatedRight.GetComponent<Image>().color = new Color(255f, 0f, 0f, 255f);
            GameManager.Instance.ElectricitySupply(IsOn);
        }
    }
}
