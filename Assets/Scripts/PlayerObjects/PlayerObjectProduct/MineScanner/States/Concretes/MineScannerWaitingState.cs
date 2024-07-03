using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScannerWaitingState : MineScannerStateBase
{
    public MineScannerWaitingState(MineScanner mineScanner, IMineScannerStateService mineScannerStateService) : base(mineScanner, mineScannerStateService)
    {
    }

    public override void EnterState()
    {
        _mineScanner.ScanParticleObject.transform.GetChild(0).GetComponent<ParticleSystem>().startColor = Color.green;
        //_mineScanner.ScanParticleObject.SetActive(false);
    }

    public override void ExitState()
    {
    }

    public override void UpdateState()
    {
    }
}
