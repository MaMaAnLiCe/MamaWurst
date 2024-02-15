using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMOD;

public class MouseClick : MonoBehaviour
{
    public InputActionReference leftClick;
    public InputAction mouse;


    private void Awake()
    {
        mouse.Enable();
        leftClick.action.performed += Listening;
    }

    private void Listening(InputAction.CallbackContext obj)
    {
        
    }
}
