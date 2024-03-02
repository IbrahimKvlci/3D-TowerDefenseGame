using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : IEnemyStateService
{
    public IEnemyState CurrentEnemyState { get; set; }


    public void SwitchState(IEnemyState state)
    {
        CurrentEnemyState.ExitState();
        CurrentEnemyState = state;
        CurrentEnemyState.EnterState();
    }

    public void Initialize(IEnemyState state)
    {
        CurrentEnemyState = state;
        state.EnterState();
    }
}
