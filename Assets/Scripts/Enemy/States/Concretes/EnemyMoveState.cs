using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyStateBase
{
    public event EventHandler OnEnemyMoveStarted;
    public event EventHandler OnEnemyMoveFinished;

    private bool goAway;

    private readonly IEnemyMovementService _enemyMovementService;

    public EnemyMoveState(Enemy enemy, IEnemyStateService enemyStateService, IEnemyMovementService enemyMovementService) : base(enemy, enemyStateService)
    {
        _enemyMovementService = enemyMovementService;
    }

    public override void EnterState()
    {
        base.EnterState();
        OnEnemyMoveStarted?.Invoke(this, EventArgs.Empty);
        goAway = true;
        _enemyMovementService.SetCanMove(_enemy, true);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(_enemy.PlayerObjectTarget != null)
        {
            Vector2 enemyPos = new Vector2(_enemy.transform.position.x, _enemy.transform.position.z);
            Vector2 playerObjectPos = new Vector2(_enemy.PlayerObjectTarget.transform.position.x, _enemy.PlayerObjectTarget.transform.position.z);

            if (Vector2.Distance(enemyPos, playerObjectPos) < 10f&&goAway)
            {
                _enemyMovementService.MakeObjectGoAway(_enemy, _enemy.PlayerObjectTarget);
            }
            else
            {
                goAway = false;
                _enemyMovementService.HandleMovement(_enemy, _enemy.PlayerObjectTarget);
            } 
        }
        if (_enemy.EnemyTriggerController.IsPlayerObjectTriggeredToBeAttacked())
        {
            _enemyStateService.SwitchState(_enemy.EnemyPrepareAttackState);
        }

    }

    public override void ExitState()
    {
        base.ExitState();
        OnEnemyMoveFinished?.Invoke(this, EventArgs.Empty);
        _enemyMovementService.SetCanMove(_enemy,false);
    }


}
