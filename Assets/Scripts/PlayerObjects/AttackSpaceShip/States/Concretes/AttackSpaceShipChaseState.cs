using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipChaseState : AttackSpaceShipStateBase
{
    private IAttackSpaceShipMovementService _attackSpaceShipMovementService;
    private IAttackSpaceShipTriggerService _attackSpaceShipTriggerService;

    public AttackSpaceShipChaseState(AttackSpaceShip attackSpaceShip, IAttackSpaceShipStateService attackSpaceShipStateService, IAttackSpaceShipMovementService attackSpaceShipMovementService,IAttackSpaceShipTriggerService attackSpaceShipTriggerService) : base(attackSpaceShip, attackSpaceShipStateService)
    {
        _attackSpaceShipMovementService = attackSpaceShipMovementService;
        _attackSpaceShipTriggerService = attackSpaceShipTriggerService;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
        if (_attackSpaceShipTriggerService.IsEnemyTriggeredToBeAttacked(_attackSpaceShip, _attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy))
        {
            _attackSpaceShipStateService.SwitchState(_attackSpaceShip.AttackSpaceShipAttackState);
        }
        if (!_attackSpaceShipTriggerService.IsEnemyStillTriggeredInTargetRange(_attackSpaceShip, _attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy))
        {
            _attackSpaceShipStateService.SwitchState(_attackSpaceShip.AttackSpaceShipIdleState);
        }
        else
        {
            HandleMovement();
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private void HandleMovement()
    {
        _attackSpaceShipMovementService.MoveToPoint(_attackSpaceShip, _attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy.transform.position, ((AttackSpaceShipSO)_attackSpaceShip.PlayerObjectSO).chaseSpeed);
    }


}
