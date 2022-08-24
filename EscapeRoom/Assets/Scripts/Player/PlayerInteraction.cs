using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public int TotalHintCount = 6;
    public int TotalFuseCount = 8;

    private float _hintAcount;
    private float _fuseAcount;

    private float _interactDiastance = 3f;
    private int _getHintCount;
    private int _getFuseCount;

    public GameObject HintScore;
    public GameObject FuseScore;

    private HintScore _hintScore;
    private PlayerSwitching _switching;

    public bool IsFinal { get; private set; }
    public bool IsShowAgain { get; private set; }
    public bool GetSwitchObject { get; private set; }
    public bool GetFuse { get; private set; }
    public bool FixSupply { get; private set; }
    public bool SolveSwitchBoard { get; private set; }

    void Start()
    {
        GetSwitchObject = false;
        GetFuse = false;
        FixSupply = false;
        SolveSwitchBoard = false;
        _getHintCount = 0;
        _hintScore = HintScore.GetComponent<HintScore>();
        _switching = GetComponent<PlayerSwitching>();

        _hintScore.UpdateText(_getHintCount, TotalHintCount);

        _hintAcount = (float)1 / (float)TotalHintCount;
        _fuseAcount = (float)1 / (float)TotalFuseCount;
    }

    void OnEnable()
    {
        UIManager.Instance.FixFuse.RemoveListener(FixedSupply);
        UIManager.Instance.FixFuse.AddListener(FixedSupply);

        GameManager.Instance.Positive.RemoveListener(ChangeStatusTrue);
        GameManager.Instance.Positive.AddListener(ChangeStatusTrue);

        GameManager.Instance.Negative.RemoveListener(ChangeStatusFalse);
        GameManager.Instance.Negative.AddListener(ChangeStatusFalse);
    }

    void Update()
    {
        UIManager.Instance.OffInteractionUI();

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _interactDiastance))
        {
            if (_switching.CameraSwitching == false)
            {
                BasicIntercation(hit);
            }
            else
            {
                FuseScore.GetComponent<FuseScore>().UpdateText(_getFuseCount, TotalFuseCount);
                UniqueInteraction(hit);
            }
            
        }

        if (IsFinal == true && GetSwitchObject == false)
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

        if (GetSwitchObject == true)
        {
            UIManager.Instance.DeleteFinalHintText();
        }

    }

    void BasicIntercation(RaycastHit hit)
    {
        if (hit.collider.CompareTag("LeftDoor"))
        {
            UIManager.Instance.OnInteractionUI();
            if (Input.GetKeyDown(KeyCode.E))
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
                UIManager.Instance.IncreaseHintImage(_hintAcount);

                if (_getHintCount < TotalHintCount)
                {
                    ObjectManager.Instance.IsEmptyHint = true;
                }

                if (_getHintCount >= TotalHintCount)
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
                    if (UIManager.Instance.IsPossibleInteraction == true)
                    {
                        UIManager.Instance.ShowBedText();
                    }
                }
                else
                {
                    UIManager.Instance.ShowCameraUI();
                    GetSwitchObject = true;
                }
            }
        }

        if (hit.collider.CompareTag("Sofa"))
        {
            UIManager.Instance.OnInteractionUI();
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (UIManager.Instance.IsPossibleInteraction == true)
                {
                    UIManager.Instance.ShowSofaText();
                }
            }
        }

    }

    void UniqueInteraction(RaycastHit hit)
    {
        if (hit.collider.CompareTag("Drawer"))
        {
            UIManager.Instance.OnInteractionUI();
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.transform.GetComponent<AnotherDrawerScript>().ChangeDoorState();
            }
        }

        if (hit.collider.CompareTag("MainDoor"))
        {
            if (hit.collider.transform.GetComponent<MainDoorScript>().IsLock == true)
            {
                UIManager.Instance.OnInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (UIManager.Instance.IsPossibleInteraction == true)
                    {
                        UIManager.Instance.ShowLockDoorText();
                    }
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

        if (hit.collider.CompareTag("Fuse"))
        {
            UIManager.Instance.OnInteractionUI();
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.gameObject.SetActive(false);
                ++_getFuseCount;

                _hintScore.UpdateText(_getHintCount, TotalHintCount);
                UIManager.Instance.IncreaseFuseImage(_fuseAcount);

                if (_getFuseCount < TotalFuseCount)
                {
                    ObjectManager.Instance.IsEmptyFuse = true;
                    ObjectManager.Instance.AlreadyExist = false;
                }

                if (_getFuseCount >= TotalFuseCount)
                {
                    GetFuse = true;
                }
            }

        }

        if (hit.collider.CompareTag("PowerSupply"))
        {
            if (GetFuse == true)
            {
                UIManager.Instance.OnInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    UIManager.Instance.ShowSupplyPanel();
                }
            }

        }

        if (hit.collider.CompareTag("SwitchBoard"))
        {
            if (FixSupply == true)
            {
                UIManager.Instance.OnInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {
                    UIManager.Instance.ShowSwitchBoard();
                }
            }

        }

        if (hit.collider.CompareTag("Projector"))
        {
            if (SolveSwitchBoard == true)
            {
                UIManager.Instance.OnInteractionUI();
                if (Input.GetKeyDown(KeyCode.E))
                {

                }
            }

        }

        

        if (hit.collider.CompareTag("Computer"))
        {
            UIManager.Instance.OnInteractionUI();
            if (Input.GetKeyDown(KeyCode.E))
            {

            }

        }

        if (hit.collider.CompareTag("Laptop"))
        {
            UIManager.Instance.OnInteractionUI();
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (UIManager.Instance.IsPossibleInteraction == true)
                {
                    UIManager.Instance.ShowLaptopText();
                }
            }

        }
    }

    void FixedSupply()
    {
        FixSupply = true;
    }

    void ChangeStatusTrue()
    {
        SolveSwitchBoard = true;
    }

    void ChangeStatusFalse()
    {
        SolveSwitchBoard = false;
    }

    void OnDisable()
    {
        UIManager.Instance.FixFuse.RemoveListener(FixedSupply);
        GameManager.Instance.Positive.RemoveListener(ChangeStatusTrue);
        GameManager.Instance.Negative.RemoveListener(ChangeStatusFalse);
    }
}
