using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControlsEditor : MonoBehaviour
{
    public InputAction look;

    public void invertX()
    {
        Debug.Log(look.processors);
    }
}
