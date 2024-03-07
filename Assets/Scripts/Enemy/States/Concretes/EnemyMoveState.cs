using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyStateBase
{
    public EnemyMoveState(Enemy enemy, IEnemyStateService enemyStateService) : base(enemy, enemyStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        _enemy.EnemyMovementService.HandleMovement(_enemy.PlayerObjectTarget);
        if (_enemy.EnemyTriggerController.IsPlayerObjectTriggeredToBeAttacked())
        {
            Debug.Log("triggered");
            _enemyStateService.SwitchState(_enemy.EnemyAttackState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
        _enemy.EnemyMovement.CanMove=false;
    }


}
