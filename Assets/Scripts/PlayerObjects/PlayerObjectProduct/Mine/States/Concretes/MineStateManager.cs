using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineStateManager : IMineStateService
{
    public IMineState CurrentMineState { get; set; }

    public void Initialize(IMineState state)
    {

        CurrentMineState = state;
        state.EnterState();
    }

    public void SwitchState(IMineState state)
    {
        CurrentMineState.ExitState();
        CurrentMineState = state;
        CurrentMineState.EnterState();
    }
}
