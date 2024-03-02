using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateBase : IEnemyState
{
    protected Enemy _enemy;
    protected IEnemyStateService _enemyStateService;

    public EnemyStateBase(Enemy enemy, IEnemyStateService enemyStateService)
    {
        _enemy = enemy;
        _enemyStateService = enemyStateService;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
        if(_enemy.PlayerObjectTarget == null)
        {
            _enemyStateService.SwitchState(_enemy.EnemyTriggerState);
        }
    }
}
