using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : IGameStateService
{
    public IGameState CurrentGameState { get; set; }

    public void Initialize(IGameState state)
    {
        CurrentGameState = state;
        state.EnterState();
    }

    public void SwitchState(IGameState state)
    {
        CurrentGameState.ExitState();
        CurrentGameState = state;
        CurrentGameState.EnterState();
    }
}
