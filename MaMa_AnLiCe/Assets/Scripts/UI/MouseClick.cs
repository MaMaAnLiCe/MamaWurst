using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using FMODUnity;

public class MouseClick : MonoBehaviour
{
    public InputActionReference leftClick;
    public EventReference mouseClick;

    private void Awake()
    {
        leftClick.action.Enable();
        leftClick.action.performed += Listening;
        DontDestroyOnLoad(gameObject);
    }

    private void Listening(InputAction.CallbackContext obj)
    {
        try
        {
            RuntimeManager.PlayOneShot(mouseClick);
        }
        catch
        {

        }


    }
}
