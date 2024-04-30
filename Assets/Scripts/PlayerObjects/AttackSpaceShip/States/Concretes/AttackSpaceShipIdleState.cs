using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackSpaceShipIdleState : AttackSpaceShipStateBase
{
    private IAttackSpaceShipMovementService _attackSpaceShipMovementService;

    public AttackSpaceShipIdleState(AttackSpaceShip attackSpaceShip, IAttackSpaceShipStateService attackSpaceShipStateService, IAttackSpaceShipMovementService attackSpaceShipMovementService) : base(attackSpaceShip, attackSpaceShipStateService)
    {
        _attackSpaceShipMovementService = attackSpaceShipMovementService;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (CheckIsSpaceShipAtDestionation())
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
