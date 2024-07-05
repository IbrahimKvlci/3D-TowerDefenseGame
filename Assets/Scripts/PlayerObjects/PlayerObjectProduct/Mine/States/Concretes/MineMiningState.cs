using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMiningState : MineStateBase
{
    public event EventHandler OnMiningStarted;
    public event EventHandler OnMiningFinished;

    public MineMiningState(Mine mine, IMineStateService mineStateService) : base(mine, mineStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        OnMiningStarted?.Invoke(this, EventArgs.Empty);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(_mine.MinePoint.MineCount > 0)
        {
            float miningCountPerTime = 0.1f*Time.deltaTime*_mine.Player.PlayerUpgrading.MiningSpeedMultiplier;

            _mine.Player.PlayerShopping.MineObjects.Find(p => p.MineObjectSO.id == _mine.MineObject.MineObjectSO.id).Count+= miningCountPerTime;
            _mine.Player.PlayerShopping.MineObjects.Find(p => p.MineObjectSO.id == _mine.MineObject.MineObjectSO.id).CurrentCollectedCount += miningCountPerTime;
            _mine.MinePoint.MineCount-= miningCountPerTime;
        }
        else
        {
            OnMiningFinished?.Invoke(this, EventArgs.Empty);

        }

    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
