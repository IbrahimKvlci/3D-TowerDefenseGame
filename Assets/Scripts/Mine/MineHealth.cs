using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineHealth : PlayerObjectHealth
{
    [SerializeField] private MineSO mineSO;

    private void Start()
    {
        Health = mineSO.healthMax;
    }
}
