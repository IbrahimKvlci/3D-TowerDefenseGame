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
        Debug.Log("Mining State");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(_mine.MinePoint.MineCount > 0)
        {
            _mine.Player.PlayerShopping.MineObjects.Find(p => p.MineObjectSO.id == _mine.MineObject.MineObjectSO.id).Count+=0.01f;
            _mine.MinePoint.MineCount-=0.01f;
        }
        

    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
