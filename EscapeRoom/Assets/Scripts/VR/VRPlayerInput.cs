using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;

public class VRPlayerInput : MonoBehaviour
{
    public float X { get; set; }
    public float Z { get; set; }

    [HideInInspector]
    public Vector2 RightThumStick;
    [HideInInspector]
    public Vector2 LeftThumStick;

    void Update()
    {
        X = Z = 0f;
        RightThumStick = Vector2.zero;
        ControllerInput();
    }

    void ControllerInput()
    {
        if (OVRInput.GetDown(OVRInput.Button.SecondaryThumbstick))
        {
            UIManager.Instance.ShowMenu();
        }

        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            LeftThumStick = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
            PlayerMoveDirectionSet();
        }

        if (OVRInput.Get(OVRInput.Touch.SecondaryThumbstick))
        {
            RightThumStick = OVRInput.Get(OVRInput.Axis2D.SecondaryThumbstick);
        }
    }

    void PlayerMoveDirectionSet()
    {
        var absX = Mathf.Abs(LeftThumStick.x);
        var absY = Mathf.Abs(LeftThumStick.y);

        if (absX > absY)
        {
            if (LeftThumStick.x > 0)
            {
                X = LeftThumStick.x;
            }
            else
            {
                X = LeftThumStick.x;
            }
        }
        else
        {
            if (LeftThumStick.y > 0)
            {
                Z = LeftThumStick.y;
            }
            else
            {
                Z = LeftThumStick.y;
            }
        }
    }
}
