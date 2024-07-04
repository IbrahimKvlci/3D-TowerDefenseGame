using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScannerIdleState : MineScannerStateBase
{
    private IMineScannerService _mineScannerService;
    public MineScannerIdleState(MineScanner mineScanner, IMineScannerStateService mineScannerStateService,IMineScannerService mineScannerService) : base(mineScanner, mineScannerStateService)
    {
        _mineScannerService = mineScannerService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _mineScanner.EngineParticleObject.gameObject.SetActive(true);
        _mineScannerService.SetMinePointToScanner(_mineScanner, MinePointController.Instance.MinePointList);
        _mineScannerStateService.SwitchState(_mineScanner.MineScannerScanningState);
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }
}
