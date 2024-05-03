using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetState : TurretStateBase
{
    protected private ITurretTriggerService _turretTriggerService;

    public TurretTargetState(Turret turret, ITurretStateService turretStateService, ITurretTriggerService turretTriggerService) : base(turret, turretStateService)
    {
        _turretTriggerService = turretTriggerService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _turret.TurretTrigger.TriggeredEnemy = null;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _turret.TurretTrigger.TriggeredEnemy= _turretTriggerService.GetTriggeredEnemy(_turret.TurretTrigger, ((TurretSO)_turret.PlayerObjectSO).attackRange, _turret.TurretTrigger.LayerMask);
        if (_turret.TurretTrigger.TriggeredEnemy != null) _turretStateService.SwitchState(_turret.TurretFireState);
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
