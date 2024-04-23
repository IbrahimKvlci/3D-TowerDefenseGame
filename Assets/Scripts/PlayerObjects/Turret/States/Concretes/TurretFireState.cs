using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFireState : TurretStateBase
{
    private float timer;

    protected private ITurretTriggerService _turretTriggerService;
    protected private ITurretAttackService _turretAttackService;

    public TurretFireState(Turret turret, ITurretStateService turretStateService, ITurretAttackService turretAttackService,ITurretTriggerService turretTriggerService) : base(turret, turretStateService)
    {
        _turretTriggerService = turretTriggerService; 
        _turretAttackService = turretAttackService;
    }

    public override void EnterState()
    {
        base.EnterState();
        timer = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        timer += Time.deltaTime;
        
        if(_turretTriggerService.IsEnemyStillTriggered(_turret.TurretTrigger, _turret.TurretTrigger.TriggeredEnemy, ((TurretSO)_turret.PlayerObjectSO).range, _turret.TurretTrigger.LayerMask))
        {
            if (timer > ((TurretSO)_turret.PlayerObjectSO).fireDuration)
            {
                timer = 0;
                _turretAttackService.Attack(_turret.TurretTrigger.TriggeredEnemy, ((TurretSO)_turret.PlayerObjectSO).damage);
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
    }
}
