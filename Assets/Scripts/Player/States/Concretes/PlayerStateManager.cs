using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateManager : IPlayerStateService
{
    public IPlayerState CurrentPlayerState { get; set; }


    public void SwitchState(IPlayerState state)
    {
        CurrentPlayerState.ExitState();
        CurrentPlayerState = state;
        CurrentPlayerState.EnterState();
    }

    public void Initialize(IPlayerState state)
    {
        CurrentPlayerState = state;
        state.EnterState();
    }
}
