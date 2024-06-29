using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineIdleState : MineStateBase
{
    private readonly IMineTriggerService _mineTriggerService;

    public MineIdleState(Mine mine, IMineStateService mineStateService, IMineTriggerService mineTriggerService) : base(mine, mineStateService)
    {
        _mineTriggerService = mineTriggerService;
        
    }

    public override void EnterState()
    {
        base.EnterState();
        if (_mineTriggerService.IsMineAtMinePoint(_mine, _mine.LayerMask,out MinePoint minePoint))
        {
            if (minePoint.MineScanner != null)
            {
                GameObject.Destroy(minePoint.MineScanner.gameObject);
            }
            _mine.MinePoint=minePoint;
            _mineStateService.SwitchState(_mine.MineMiningState);
        }
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
