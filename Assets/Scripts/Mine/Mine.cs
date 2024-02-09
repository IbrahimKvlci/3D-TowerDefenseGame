using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : PlayerObjectsBase
{

    [SerializeField] private MineObjectSO mineObjectSO;
    [SerializeField] private MineSO mineSO;

    private float miningTimer;


    private void Update()
    {
        HandleMiningMineObject(mineObjectSO);
    }

    private void HandleMiningMineObject(MineObjectSO mineObjectSO)
    {
        miningTimer += Time.deltaTime;
        if (miningTimer >= mineObjectSO.miningTimerMax)
        {
            miningTimer = 0;
            Debug.Log($"{mineObjectSO.title} was mined");
        }
    }

}
