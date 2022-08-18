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

    void Start()
    {
        _getHintCount = 0;
        _hintScore = HintScore.GetComponent<HintScore>();

        _hintScore.UpdateText(_getHintCount, TotalHintCount);
    }

    void Update()
    {
        UIManager.Instance.OffDoorInteractionUI();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactDiastance))
        {
            if (hit.collider.CompareTag("LeftDoor"))
            {
                UIManager.Instance.OnDoorInteractionUI();
                if(Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<LeftDoorScript>().ChangeDoorState();
                }
            }

            if (hit.collider.CompareTag("RightDoor"))
            {
                UIManager.Instance.OnDoorInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<RightDoorScript>().ChangeDoorState();
                }
                
            }

            if (hit.collider.CompareTag("UpDownDoor"))
            {
                UIManager.Instance.OnDoorInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<UpDownDoorScript>().ChangeDoorState();
                }

            }

            if (hit.collider.CompareTag("Drawer"))
            {
                UIManager.Instance.OnDoorInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hit.collider.transform.GetComponent<DrawerScript>().ChangeDoorState();
                }

            }

            if (hit.collider.CompareTag("Hint"))
            {
                UIManager.Instance.OnDoorInteractionUI();
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
        }

        if(IsFinal == true)
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

    }
}
