using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class VRPlayerInput : MonoBehaviour
{
    public float X { get; set; }
    public float Z { get; set; }

    public Vector2 ThumStick;

    void Update()
    {
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            UIManager.Instance.ShowMenu();
        }

        if(OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            ThumStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        }
    }
}
