using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMineScannerState
{
    void EnterState();
    void UpdateState();
    void ExitState();
}
