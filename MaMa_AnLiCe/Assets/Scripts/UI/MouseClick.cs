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
    public EventReference mouseClickUp;

    private void Awake()
    {
        leftClick.action.Enable();
        leftClick.action.started += Listening;
        leftClick.action.canceled += ListeningUp;
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


    }private void ListeningUp(InputAction.CallbackContext obj)
    {
        try
        {
            RuntimeManager.PlayOneShot(mouseClickUp);
        }
        catch
        {

        }


    }
}
