using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : SingletonBehaviour<ObjectManager>
{
    public bool IsEmpty { get; set; }

    public GameObject[] HintSpwanPositions;

    public GameObject[] Hints;

    public GameObject Hint;

    void Start()
    {
        IsEmpty = true;

        Hints = new GameObject[HintSpwanPositions.Length];

        for (int i = 0; i < HintSpwanPositions.Length; ++i)
        {
            Hints[i] = Instantiate(Hint) as GameObject;
            Hints[i].transform.SetParent(HintSpwanPositions[i].transform, false);
            Hints[i].SetActive(false);
        }
    }


    void Update()
    {
        if (IsEmpty == true)
        {
            int randomNumber = Random.Range(0, Hints.Length);
            Hints[randomNumber].SetActive(true);
            IsEmpty = false;
        }
    }
}
