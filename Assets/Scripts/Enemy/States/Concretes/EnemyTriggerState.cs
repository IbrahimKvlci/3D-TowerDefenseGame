using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerState : EnemyStateBase
{
    private readonly IEnemyDetectPlayerObjectService _enemyTriggerService;

    public EnemyTriggerState(Enemy enemy, IEnemyStateService enemyStateService, IEnemyDetectPlayerObjectService enemyTriggerService) : base(enemy, enemyStateService)
    {
        _enemyTriggerService = enemyTriggerService;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_enemyTriggerService.TryGetClosestPlayerObject(_enemy,PlayerObjectPooling.Instance.PlayerObjectList,out PlayerObject playerObject))
        {
            _enemy.PlayerObjectTarget = playerObject;
            _enemy.EnemyStateService.SwitchState(_enemy.EnemyMoveState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }


}
