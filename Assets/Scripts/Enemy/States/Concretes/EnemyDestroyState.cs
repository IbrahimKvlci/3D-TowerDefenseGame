using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyState : EnemyStateBase
{
    private readonly IEnemyHealthService _enemyHealthService;

    public EnemyDestroyState(Enemy enemy, IEnemyStateService enemyStateService, IEnemyHealthService enemyHealthService) : base(enemy, enemyStateService)
    {
        _enemyHealthService = enemyHealthService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _enemyHealthService.DestroySelf(_enemy);
    }

    public override void UpdateState()
    {
        base.UpdateState();

    }

    public override void ExitState()
    {
        base.ExitState();
    }


}
