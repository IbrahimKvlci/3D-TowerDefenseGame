using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStateManager : ITurretStateService
{
    public ITurretState CurrentTurretState { get; set; }

    public void Initialize(ITurretState state)
    {
        CurrentTurretState = state;
        state.EnterState();
    }

    public void SwitchState(ITurretState state)
    {
        CurrentTurretState.ExitState();
        CurrentTurretState = state;
        CurrentTurretState.EnterState();
    }
}
