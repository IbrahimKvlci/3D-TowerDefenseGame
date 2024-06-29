using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFreezingState : TurretStateBase
{
    public TurretFreezingState(Turret turret, ITurretStateService turretStateService) : base(turret, turretStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_turret.IsPlaced)
        {
            _turretStateService.SwitchState(_turret.TurretTargetState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
