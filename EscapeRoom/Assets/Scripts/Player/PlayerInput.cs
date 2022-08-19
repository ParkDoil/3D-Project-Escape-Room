using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float X { get; set; }
    public float Z { get; set; }

    void Update()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            UIManager.Instance.ShowMenu();
        }
    }
}
