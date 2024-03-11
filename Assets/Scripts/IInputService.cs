using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService
{
    public event EventHandler OnMouseScrollScrolled;
    public event EventHandler OnLockKeyDown;

    public Vector2 GetMousePositionInCamera();
    public Vector3 GetMousePositionOnAPlane(LayerMask planeLayer);
    public float GetMouseScrollValue();
}
