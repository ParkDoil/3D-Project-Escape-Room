using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private float _interactDiastance = 3f;
    private int _getHintCount;

    public int TotalHintCount = 6;

    public GameObject HintScore;

    HintScore _hintScore;

    public bool IsFinal { get; private set; }
    public bool IsShowAgain { get; private set; }
    public bool GetFinalObject { get; private set; }

    void Start()
    {
        GetFinalObject = false;
        _getHintCount = 0;
        _hintScore = HintScore.GetComponent<HintScore>();

        _hintScore.UpdateText(_getHintCount, TotalHintCount);
    }

    void Update()
    {
        UIManager.Instance.OffInteractionUI();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactDiastance))
        {

            if(hit.collider.CompareTag("MainDoor"))
            {
                if (hit.collider.transform.GetComponent<MainDoorScript>().IsLock == true)
                {
                    UIManager.Instance.OnInteractionUI();

                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        UIManager.Instance.ShowLockDoorText();
                    }
                }
            }

            if (hit.collider.CompareTag("LeftDoor"))
            {
                UIManager.Instance.OnInteractionUI();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<LeftDoorScript>().ChangeDoorState();
                }
            }

            if (hit.collider.CompareTag("RightDoor"))
            {
                UIManager.Instance.OnInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<RightDoorScript>().ChangeDoorState();
                }
                
            }

            if (hit.collider.CompareTag("UpDownDoor"))
            {
                UIManager.Instance.OnInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<UpDownDoorScript>().ChangeDoorState();
                }

            }

            if (hit.collider.CompareTag("Drawer"))
            {
                UIManager.Instance.OnInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<DrawerScript>().ChangeDoorState();
                }

            }

            if (hit.collider.CompareTag("Hint"))
            {
                UIManager.Instance.OnInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.gameObject.SetActive(false);
                    ++_getHintCount;

                    _hintScore.UpdateText(_getHintCount, TotalHintCount);

                    if (_getHintCount < TotalHintCount)
                    {
                        ObjectManager.Instance.IsEmpty = true;
                    }

                    if(_getHintCount >= TotalHintCount)
                    {
                        UIManager.Instance.ShowFinalHintText();
                        IsShowAgain = false;
                        IsFinal = true;
                    }
                }

            }

            if (hit.collider.CompareTag("Bed"))
            {
                UIManager.Instance.OnInteractionUI();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (IsFinal == false)
                    {
                        UIManager.Instance.ShowBedText();
                    }
                    else
                    {
                        UIManager.Instance.ShowCameraUI();
                        GetFinalObject = true;
                    }
                }
            }

            if (hit.collider.CompareTag("Sofa"))
            {
                UIManager.Instance.OnInteractionUI();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (IsFinal == false)
                    {
                        UIManager.Instance.ShowSofaText();
                    }
                    else
                    {

                    }
                }
            }

            if (hit.collider.CompareTag("KeyPad"))
            {
                UIManager.Instance.OnInteractionUI();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    UIManager.Instance.ShowKeyPad();
                }
            }
        }

        if (IsFinal == true && GetFinalObject == false)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                IsShowAgain = !IsShowAgain;

                if (IsShowAgain == true)
                {
                    UIManager.Instance.ShowFinalHintText();
                }
                else
                {
                    UIManager.Instance.ExitFinalHintText();
                }
            }
        }

        if (GetFinalObject == true)
        {
            UIManager.Instance.DeleteFinalHintText();
        }

    }
}
