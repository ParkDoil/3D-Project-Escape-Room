using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OVRInput;

public class MainSceneRaycast : MonoBehaviour
{
    public Transform FristCam;
    public Transform SecondCam;

    private Transform CenterCamera;
    public Transform Dot;

    private VRPlayerSwitching _switching;

    void Start()
    {
        _switching = GetComponent<VRPlayerSwitching>();
    }

    void Update()
    {

        if (_switching.CameraSwitching == false)
        {
            CenterCamera = FristCam;
        }
        else
        {
            CenterCamera = SecondCam;
        }

        Ray ray = new Ray(CenterCamera.position, CenterCamera.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3000))
        {
            Debug.Log("����ĳ��Ʈ �¾Ҵ�!");
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                Debug.Log("UI �¾Ҵ�!");
                Dot.gameObject.SetActive(true);
                Dot.position = hit.point;
            }
            else
            {
                Dot.gameObject.SetActive(false);
            }


            // 4. dot�� �浹 �� �� �� Ŭ���� �� �ֵ��� �Ѵ�.
            // ���� ���� Ȱ��ȭ ���¸�
            if (Dot.gameObject.activeSelf)
            {
                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    // ��ư ��ũ��Ʈ�� �����´�
                    UnityEngine.UI.Button btn = hit.transform.GetComponent<UnityEngine.UI.Button>();
                    // ���� btn�� null�� �ƴ϶��
                    if (btn != null)
                    {
                        btn.onClick.Invoke();
                    }
                }
            }
        }

        else
        {
            Dot.gameObject.SetActive(false);
        }
    }
}
