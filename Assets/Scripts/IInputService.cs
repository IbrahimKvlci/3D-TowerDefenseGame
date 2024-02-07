using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputService
{
    public event EventHandler OnMouseScrollScrolled;

    public Vector2 GetMousePositionInCamera();
    public float GetMouseScrollValue();
}
