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


            // 4. dot이 충돌 중 일 때 클릭할 수 있도록 한다.
            // 만약 점이 활성화 상태면
            if (Dot.gameObject.activeSelf)
            {
                if (OVRInput.GetDown(OVRInput.Button.One))
                {
                    // 버튼 스크립트를 가져온다
                    UnityEngine.UI.Button btn = hit.transform.GetComponent<UnityEngine.UI.Button>();
                    // 만약 btn이 null이 아니라면
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
