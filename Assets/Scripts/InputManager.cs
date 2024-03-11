using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IInputService
{
    public event EventHandler OnMouseScrollScrolled;
    public event EventHandler OnLockKeyDown;

    InputActions _inputActions;

    private Vector2 _mousePosition;
    private float _mouseScroll;

    private void Awake()
    {
        _inputActions = new InputActions();
        _inputActions.Enable();

        _inputActions.Camera.Control.performed += Control_performed;
        _inputActions.Camera.Zoom.performed += Zoom_performed;
        _inputActions.Camera.Lock.performed += Lock_performed;
    }

    private void Lock_performed(InputAction.CallbackContext obj)
    {
        OnLockKeyDown?.Invoke(this, EventArgs.Empty);
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

    public Vector3 GetMousePositionOnAPlane(LayerMask planeLayer)
    {
        Vector3 mousePos = _mousePosition;
        Vector3 lastPos = mousePos;

        mousePos.z = Camera.main.nearClipPlane;
        Ray ray=Camera.main.ScreenPointToRay(mousePos);
        if(Physics.Raycast(ray,out RaycastHit hitInfo, 10000, planeLayer))
        {
            lastPos = hitInfo.point;
        }

        return lastPos;
    }
}
