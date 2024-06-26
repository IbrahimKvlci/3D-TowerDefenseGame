using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObject : MonoBehaviour
{
    public event EventHandler OnMineObjectCountChanged;

    [field:SerializeField] public MineObjectSO MineObjectSO { get; set; }

    private float count = 100;
    public float Count { 
        get { return count; } 
        set { count = value; OnMineObjectCountChanged?.Invoke(this, EventArgs.Empty); }
    }

}
