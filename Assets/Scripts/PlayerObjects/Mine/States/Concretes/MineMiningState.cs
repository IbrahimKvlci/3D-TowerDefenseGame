using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineMiningState : MineStateBase
{


    public MineMiningState(Mine mine, IMineStateService mineStateService) : base(mine, mineStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

    }

    public override void UpdateState()
    {
        base.UpdateState();
        _mine.Player.PlayerShopping.MineObjects.Find(p => p.MineObjectSO.id == _mine.MineObject.MineObjectSO.id).Count++;

    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
