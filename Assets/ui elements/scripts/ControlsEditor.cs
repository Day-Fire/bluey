using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsEditor : MonoBehaviour
{
    public InputAction look;

    public void invertX()
    {
        look.AddBinding("<Gamepad>/leftStick").WithProcessor("invertVector2(invertX=false)");
    }
}
