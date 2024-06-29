using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineIdleState : MineStateBase
{
    private readonly IMineTriggerService _mineTriggerService;
    private readonly IMineScannerService _mineScannerService;

    public MineIdleState(Mine mine, IMineStateService mineStateService, IMineTriggerService mineTriggerService, IMineScannerService mineScannerService) : base(mine, mineStateService)
    {
        _mineTriggerService = mineTriggerService;
        _mineScannerService = mineScannerService;
    }

    public override void EnterState()
    {
        base.EnterState();
        if (_mineTriggerService.IsMineAtMinePoint(_mine, _mine.LayerMask,out MinePoint minePoint))
        {
            if (minePoint.MineScanner != null)
            {
               _mineScannerService.DestroyMineScanner(minePoint.MineScanner);
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
