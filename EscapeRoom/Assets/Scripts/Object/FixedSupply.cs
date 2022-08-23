using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FixedSupply : MonoBehaviour
{
    Image _image;

    void Awake()
    {
        _image = GetComponent<Image>();
    }
    void OnEnable()
    {
        UIManager.Instance.FixFuse.RemoveListener(Fix);
        UIManager.Instance.FixFuse.AddListener(Fix);
    }

    void Fix()
    {
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 255f);
    }

    void OnDisable()
    {
        UIManager.Instance.FixFuse.RemoveListener(Fix);
    }
}
