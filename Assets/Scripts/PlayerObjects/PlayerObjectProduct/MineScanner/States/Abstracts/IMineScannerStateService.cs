using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMineScannerStateService
{
    public IMineScannerState CurrentMineScannerState { get; set; }
    void Initialize(IMineScannerState state);
    void SwitchState(IMineScannerState state);
}

