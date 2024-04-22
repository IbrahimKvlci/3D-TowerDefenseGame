using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTargetState : TurretStateBase
{
    public TurretTargetState(Turret turret, ITurretStateService turretStateService) : base(turret, turretStateService)
    {
    }
}
