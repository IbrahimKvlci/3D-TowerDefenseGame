using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyStateBase
{
    public event EventHandler OnEnemyAttacked;

    private float timer;

    private readonly IEnemyAttackService _enemyAttackService;

    public EnemyAttackState(Enemy enemy, IEnemyStateService enemyStateService,IEnemyAttackService enemyAttackService) : base(enemy, enemyStateService)
    {
        _enemyAttackService= enemyAttackService;
    }

    public override void EnterState()
    {
        base.EnterState();
        OnEnemyAttacked?.Invoke(this, EventArgs.Empty);
        timer = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        timer += Time.deltaTime;
        if (timer > _enemy.EnemySO.attackAnimationToAttackTimerMax)
        {
            timer = 0;
            _enemyAttackService.Attack(_enemy.PlayerObjectTarget, _enemy.EnemySO.damage);
            InGameSoundManager.Instance.PlayAudioNormalized(_enemy.EnemySoundController.EnemySoundEffectsSO.hitAudioClip, _enemy.transform.position,0.5f);
            _enemyStateService.SwitchState(_enemy.EnemyPrepareAttackState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }


}
