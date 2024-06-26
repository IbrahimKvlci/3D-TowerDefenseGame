using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObject : MonoBehaviour
{
    public event EventHandler OnMineObjectCountChanged;
    public event EventHandler OnMineObjectCurrentCollectedCountChanged;


    [field:SerializeField] public MineObjectSO MineObjectSO { get; set; }

    private float _count = 100;
    public float Count { 
        get { return _count; } 
        set { _count = value; OnMineObjectCountChanged?.Invoke(this, EventArgs.Empty); }
    }

    private float _currentCollectedCount = 10;
    public float CurrentCollectedCount
    {
        get { return _currentCollectedCount; }
        set { _currentCollectedCount = value; OnMineObjectCurrentCollectedCountChanged?.Invoke(this, EventArgs.Empty); }
    }

}
