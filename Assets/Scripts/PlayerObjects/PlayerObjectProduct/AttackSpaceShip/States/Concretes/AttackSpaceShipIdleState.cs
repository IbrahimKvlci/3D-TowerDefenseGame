using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackSpaceShipIdleState : AttackSpaceShipStateBase
{
    private IAttackSpaceShipMovementService _attackSpaceShipMovementService;
    private IAttackSpaceShipTriggerService _attackSpaceShipTriggerService;

    public AttackSpaceShipIdleState(AttackSpaceShip attackSpaceShip, IAttackSpaceShipStateService attackSpaceShipStateService, IAttackSpaceShipMovementService attackSpaceShipMovementService,IAttackSpaceShipTriggerService attackSpaceShipTriggerService) : base(attackSpaceShip, attackSpaceShipStateService)
    {
        _attackSpaceShipMovementService = attackSpaceShipMovementService;
        _attackSpaceShipTriggerService = attackSpaceShipTriggerService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy = null;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (CheckIsSpaceShipAtDestionation())
        {
            HandleMovement();
        }

        if (_attackSpaceShipTriggerService.GetTriggeredEnemy(_attackSpaceShip,_attackSpaceShip.AttackSpaceShipTrigger.LayerMask)!=null)
        {
            _attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy = _attackSpaceShipTriggerService.GetTriggeredEnemy(_attackSpaceShip, _attackSpaceShip.AttackSpaceShipTrigger.LayerMask);
            _attackSpaceShipStateService.SwitchState(_attackSpaceShip.AttackSpaceShipChaseState);
        }
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private void HandleMovement()
    {
        if (_attackSpaceShipMovementService.RandomPoint(_attackSpaceShip.transform.position, ((AttackSpaceShipSO)_attackSpaceShip.PlayerObjectSO).maxMoveRange, out Vector3 point))
        {
            _attackSpaceShipMovementService.MoveToPoint(_attackSpaceShip, point, ((AttackSpaceShipSO)_attackSpaceShip.PlayerObjectSO).idleSpeed);
        }
    }

    private bool CheckIsSpaceShipAtDestionation()
    {
        if(_attackSpaceShip.transform.position==_attackSpaceShip.GetComponent<NavMeshAgent>().destination)
        {
            return true;
        }
        return false;
    }
}
