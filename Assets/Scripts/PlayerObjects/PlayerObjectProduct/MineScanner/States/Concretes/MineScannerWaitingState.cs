using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScannerWaitingState : MineScannerStateBase
{
    public event EventHandler OnMineScanned;

    public MineScannerWaitingState(MineScanner mineScanner, IMineScannerStateService mineScannerStateService) : base(mineScanner, mineScannerStateService)
    {
    }

    public override void EnterState()
    {
        _mineScanner.ScanParticleObject.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = Color.green;
        //_mineScanner.ScanParticleObject.SetActive(false);

        OnMineScanned?.Invoke(this,EventArgs.Empty);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }
}
