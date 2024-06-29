using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScannerFreezingState : MineScannerStateBase
{
    public MineScannerFreezingState(MineScanner mineScanner, IMineScannerStateService mineScannerStateService) : base(mineScanner, mineScannerStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_mineScanner.IsPlaced)
        {

            _mineScannerStateService.SwitchState(_mineScanner.MineScannerIdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
