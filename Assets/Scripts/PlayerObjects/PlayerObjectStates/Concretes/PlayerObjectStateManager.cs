using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectStateManager : IPlayerObjectStateService
{
    public IPlayerObjectState CurrentPlayerObjectState { get; set; }


    public void SwitchState(IPlayerObjectState state)
    {
        CurrentPlayerObjectState.ExitState();
        CurrentPlayerObjectState = state;
        CurrentPlayerObjectState.EnterState();
    }

    public void Initialize(IPlayerObjectState state)
    {
        CurrentPlayerObjectState = state;
        state.EnterState();
    }
}
