using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScannerStateBase : IMineScannerState
{
    protected MineScanner _mineScanner;
    protected IMineScannerStateService _mineScannerStateService;

    public MineScannerStateBase(MineScanner mineScanner,IMineScannerStateService mineScannerStateService)
    {
        _mineScanner = mineScanner;
        _mineScannerStateService = mineScannerStateService;
    }


    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
    }
}
