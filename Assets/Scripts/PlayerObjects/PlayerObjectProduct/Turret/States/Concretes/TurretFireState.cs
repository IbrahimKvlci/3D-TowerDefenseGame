using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFireState : TurretStateBase
{
    public event EventHandler OnTurretAttacked;
    public event EventHandler OnTurretAttackedStoped;

    private float timer;

    private readonly ITurretTriggerService _turretTriggerService;
    private readonly ITurretAttackService _turretAttackService;

    public TurretFireState(Turret turret, ITurretStateService turretStateService, ITurretAttackService turretAttackService,ITurretTriggerService turretTriggerService) : base(turret, turretStateService)
    {
        _turretTriggerService = turretTriggerService; 
        _turretAttackService = turretAttackService;
    }

    public override void EnterState()
    {
        base.EnterState();
        OnTurretAttacked?.Invoke(this, EventArgs.Empty);

        timer = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        timer += Time.deltaTime;
        
        if(_turretTriggerService.IsEnemyStillTriggered(_turret.TurretTrigger, _turret.TurretTrigger.TriggeredEnemy, ((TurretSO)_turret.PlayerObjectSO).attackRange, _turret.TurretTrigger.LayerMask))
        {
            if (timer > ((TurretSO)_turret.PlayerObjectSO).fireDuration)
            {
                timer = 0;
                _turretAttackService.Attack(_turret.TurretTrigger.TriggeredEnemy, ((TurretSO)_turret.PlayerObjectSO).damage);
                InGameSoundManager.Instance.PlayAudioFromPool(InGameSoundManager.Instance.InGameSoundEffectsSO.gunShotFx);

            }
        }
        else
        {
            _turretStateService.SwitchState(_turret.TurretTargetState);
        }
        
    }

    public override void ExitState()
    {
        base.ExitState();
        OnTurretAttackedStoped?.Invoke(this, EventArgs.Empty);
    }
}
