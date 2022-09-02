using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OVRInput;

public class MainSceneRaycast : MonoBehaviour
{
    [SerializeField] Transform FristCam;

    private Transform CenterCamera;
    [SerializeField] Transform Dot;

    private VRPlayerSwitching _switching;

    void Start()
    {
        CenterCamera = FristCam;
        _switching = GetComponent<VRPlayerSwitching>();
    }

    void Update()
    {
        Ray ray = new Ray(CenterCamera.position, CenterCamera.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 3000f))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI") || hit.transform.gameObject.layer == LayerMask.NameToLayer("Button") || hit.transform.gameObject.layer == LayerMask.NameToLayer("Slider"))
            {
                Dot.gameObject.SetActive(true);
                Dot.transform.rotation = transform.rotation;
                Dot.position = hit.point;
            }

            else
            {
                Dot.gameObject.SetActive(false);
            }

            UIAction(hit);
            
        }

        else
        {
            Dot.gameObject.SetActive(false);
        }
    }

    void UIAction(RaycastHit hit)
    {
        // 4. dot�� �浹 �� �� �� Ŭ���� �� �ֵ��� �Ѵ�.
        // ���� ���� Ȱ��ȭ ���¸�
        if (Dot.gameObject.activeSelf)
        {
            if (OVRInput.GetDown(OVRInput.Button.One))
            {
                UnityEngine.UI.Button _btn = null;
                Slider _slider = null;

                if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Button"))
                {
                    // ��ư ��ũ��Ʈ�� �����´�
                    _btn = hit.transform.GetComponent<UnityEngine.UI.Button>();
                }

                if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Slider"))
                {
                    // �����̴� ��ũ��Ʈ�� �����´�
                    _slider = hit.transform.GetComponent<Slider>();
                }

                if (_btn != null)
                {
                    _btn.onClick.Invoke();
                }

                if(_slider != null)
                {
                    if(_slider.value == _slider.maxValue)
                    {
                        _slider.value = _slider.minValue;
                        _slider.onValueChanged.Invoke(_slider.value);
                    }
                    else
                    {
                        _slider.value = _slider.maxValue;
                        _slider.onValueChanged.Invoke(_slider.value);
                    }
                }
            }
        }
    }
}
