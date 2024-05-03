using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipStateManager : IAttackSpaceShipStateService
{
    public IAttackSpaceShipState CurrentAttackSpaceShipState { get; set; }

    public void Initialize(IAttackSpaceShipState state)
    {
        CurrentAttackSpaceShipState = state;
        state.EnterState();
    }

    public void SwitchState(IAttackSpaceShipState state)
    {
        CurrentAttackSpaceShipState.ExitState();
        CurrentAttackSpaceShipState = state;
        CurrentAttackSpaceShipState.EnterState();
    }
}
