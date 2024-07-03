using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScannerScanningState : MineScannerStateBase
{
    private int lastPointIndex;

    private IMineScannerMovementService _mineScannerMovementService;
    private IMineScannerService _mineScannerService;

    public MineScannerScanningState(MineScanner mineScanner, IMineScannerStateService mineScannerStateService, IMineScannerMovementService mineScannerMovementService,IMineScannerService mineScannerService) : base(mineScanner, mineScannerStateService)
    {
        _mineScannerMovementService = mineScannerMovementService;
        _mineScannerService = mineScannerService;
    }

    public override void EnterState()
    {
        _mineScanner.MineScannerMovementController.MinePointPath = _mineScannerMovementService.CreateScannerPath(_mineScanner, MinePointController.Instance.PointList, 3, 6);
        lastPointIndex = 0;
        _mineScanner.ScanParticleObject.SetActive(true);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
        if (lastPointIndex < _mineScanner.MineScannerMovementController.MinePointPath.Count)
            HandleMovement();
        else if (_mineScanner.MinePoint == null)
            _mineScannerService.DestroyMineScanner(_mineScanner);
        else
            _mineScannerStateService.SwitchState(_mineScanner.MineScannerWaitingState);
    }

    private void HandleMovement()
    {
        _mineScannerMovementService.MoveToPoint(_mineScanner, _mineScanner.MineScannerMovementController.MinePointPath[lastPointIndex].transform, ((MineScannerSO)_mineScanner.PlayerObjectSO).speed * _mineScanner.Player.PlayerUpgrading.MineScannerSpeedMultiplier);
        if (_mineScannerMovementService.CheckMineScannerAtPoint(_mineScanner, _mineScanner.MineScannerMovementController.MinePointPath[lastPointIndex].transform))
            lastPointIndex++;
    }
}
