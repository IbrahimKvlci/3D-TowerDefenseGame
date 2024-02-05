using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    public static InputManager Instance { get; private set; }

    InputActions inputActions;

    private Vector2 mousePosition;

    private void Awake()
    {
        Instance = this;

        inputActions=new InputActions();
        inputActions.Enable();

        inputActions.Camera.Control.performed += Control_performed;

    }

    private void Control_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        mousePosition = obj.ReadValue<Vector2>();
    }


    /// <summary>
    /// It returns value between 1 and 1. (-1,-1) point is left bottom corner, (1,1) point is right top corner 
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMousePositionInCamera()
    {
        Vector2 position = new Vector2(mousePosition.x / Camera.main.pixelWidth, mousePosition.y/Camera.main.pixelHeight);
        position.x -= .5f;
        position.y -= .5f;

        position.x *= 2;
        position.y *= 2;

        return position;
    }
}
