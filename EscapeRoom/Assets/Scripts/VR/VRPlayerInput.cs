using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class VRPlayerInput : MonoBehaviour
{
    public float X { get; set; }
    public float Z { get; set; }

    public Vector2 FristThumStick;
    public Vector2 SecondThumStick;

    void Update()
    {
        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            SecondThumStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        }

        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            FristThumStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        }

        X = FristThumStick.x;
        Z = FristThumStick.y;

        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            UIManager.Instance.ShowMenu();
        }

        
    }
}
