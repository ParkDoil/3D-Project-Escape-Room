using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : SingletonBehaviour<ObjectManager>
{
    public bool IsEmptyHint { get; set; }
    public bool IsEmptyFuse { get; set; }
    public bool AlreadyExist { get; set; }

    public GameObject[] HintSpwanPositions;
    public GameObject[] Hints;
    public GameObject Hint;

    public GameObject[] FuseSpwanPositions;
    public GameObject[] Fuses;
    public GameObject Fuse;

    void OnEnable()
    {
        GameManager.Instance.ChangeMode.RemoveListener(FuseSet);

        GameManager.Instance.ChangeMode.AddListener(FuseSet);
    }

    void Start()
    {
        IsEmptyHint = true;
        IsEmptyFuse = false;

        Hints = new GameObject[HintSpwanPositions.Length];
        Fuses = new GameObject[FuseSpwanPositions.Length];

        for (int i = 0; i < HintSpwanPositions.Length; ++i)
        {
            Hints[i] = Instantiate(Hint) as GameObject;
            Hints[i].transform.SetParent(HintSpwanPositions[i].transform, false);
            Hints[i].SetActive(false);
        }

        for (int i = 0; i < FuseSpwanPositions.Length; ++i)
        {
            Fuses[i] = Instantiate(Fuse) as GameObject;
            Fuses[i].transform.SetParent(FuseSpwanPositions[i].transform, false);
            Fuses[i].SetActive(false);
        }
    }


    void Update()
    {
        if (IsEmptyHint == true)
        {
            int randomNumber = Random.Range(0, Hints.Length);
            Hints[randomNumber].SetActive(true);
            Hints[randomNumber].GetComponent<AudioSource>().Play();
            IsEmptyHint = false;
        }

        if (IsEmptyFuse == true && AlreadyExist == false)
        {
            int randomNumber = Random.Range(0, Fuses.Length);
            Fuses[randomNumber].SetActive(true);
            Fuses[randomNumber].GetComponent<AudioSource>().Play();
            IsEmptyFuse = false;
            AlreadyExist = true;
        }
    }

    void FuseSet()
    {
        IsEmptyFuse = !IsEmptyFuse;
    }

    //void OnDisable()
    //{
    //    GameManager.Instance.ChangeMode.RemoveListener(FuseSet);
    //}
}
