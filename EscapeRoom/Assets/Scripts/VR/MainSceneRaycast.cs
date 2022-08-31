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
            Debug.Log("레이캐스트 맞았다!");
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("UI"))
            {
                Debug.Log("UI 맞았다!");
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
