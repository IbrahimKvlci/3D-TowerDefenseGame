using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipFreezingState : AttackSpaceShipStateBase
{
    public AttackSpaceShipFreezingState(AttackSpaceShip attackSpaceShip, IAttackSpaceShipStateService attackSpaceShipStateService) : base(attackSpaceShip, attackSpaceShipStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_attackSpaceShip.IsPlaced)
        {
            _attackSpaceShipStateService.SwitchState(_attackSpaceShip.AttackSpaceShipIdleState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
