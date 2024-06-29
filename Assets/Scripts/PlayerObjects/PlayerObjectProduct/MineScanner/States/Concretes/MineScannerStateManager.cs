using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScannerStateManager : IMineScannerStateService
{
    public IMineScannerState CurrentMineScannerState { get; set; }

    public void Initialize(IMineScannerState state)
    {
        CurrentMineScannerState = state;
        CurrentMineScannerState.EnterState();
    }

    public void SwitchState(IMineScannerState state)
    {
        CurrentMineScannerState.ExitState();
        CurrentMineScannerState = state;
        CurrentMineScannerState.EnterState();
    }
}
