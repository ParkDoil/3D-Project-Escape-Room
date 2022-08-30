using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static OVRInput;

public class TitleSceneRaycast : MonoBehaviour
{
    public Transform CenterCamera;

    public Transform Dot;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(CenterCamera.position, CenterCamera.forward);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 3000))
        {
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
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
