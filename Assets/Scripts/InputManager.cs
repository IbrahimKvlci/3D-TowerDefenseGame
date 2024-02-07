using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IInputService
{

    InputActions _inputActions;

    private Vector2 _mousePosition;
    private float _mouseScroll;

    public event EventHandler OnMouseScrollScrolled;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Enable();

        _inputActions.Camera.Control.performed += Control_performed;
        _inputActions.Camera.Zoom.performed += Zoom_performed;
    }

    private void Zoom_performed(InputAction.CallbackContext obj)
    {
        _mouseScroll=obj.ReadValue<float>();

        OnMouseScrollScrolled?.Invoke(this, EventArgs.Empty);
    }

    private void Control_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _mousePosition = obj.ReadValue<Vector2>();
    }


    /// <summary>
    /// It returns value between 1 and 1. (-1,-1) point is left bottom corner, (1,1) point is right top corner 
    /// </summary>
    /// <returns></returns>
    public Vector2 GetMousePositionInCamera()
    {
        Vector2 position = new Vector2(_mousePosition.x / Camera.main.pixelWidth, _mousePosition.y / Camera.main.pixelHeight);
        position.x -= .5f;
        position.y -= .5f;

        position.x *= 2;
        position.y *= 2;

        return position;
    }

    public float GetMouseScrollValue()
    {
        return _mouseScroll;
    }
}
