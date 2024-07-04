using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrepareAttackState : EnemyStateBase
{
    private float timer;

    public EnemyPrepareAttackState(Enemy enemy, IEnemyStateService enemyStateService) : base(enemy, enemyStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        timer = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (!_enemy.EnemyTriggerController.IsPlayerObjectTriggeredToBeAttacked())
        {
            Debug.Log("move");
            _enemyStateService.SwitchState(_enemy.EnemyMoveState);
        }

        timer += Time.deltaTime;
        if (timer > _enemy.EnemySO.attackSpeed)
        {
            timer = 0;
            _enemyStateService.SwitchState(_enemy.EnemyAttackState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }


}
