using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePoint : MonoBehaviour
{
    public bool IsActive { get; set; }

    private void Awake()
    {
        IsActive = false;
    }
}
