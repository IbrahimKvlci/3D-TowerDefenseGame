using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyStateBase
{
    private readonly IEnemyMovementService _enemyMovementService;

    public EnemyMoveState(Enemy enemy, IEnemyStateService enemyStateService, IEnemyMovementService enemyMovementService) : base(enemy, enemyStateService)
    {
        _enemyMovementService = enemyMovementService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _enemyMovementService.SetCanMove(_enemy, true);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(_enemy.PlayerObjectTarget != null)
        {
            _enemyMovementService.HandleMovement(_enemy, _enemy.PlayerObjectTarget);
        }
        if (_enemy.EnemyTriggerController.IsPlayerObjectTriggeredToBeAttacked())
        {
            _enemyStateService.SwitchState(_enemy.EnemyPrepareAttackState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _enemyMovementService.SetCanMove(_enemy,false);
    }


}
