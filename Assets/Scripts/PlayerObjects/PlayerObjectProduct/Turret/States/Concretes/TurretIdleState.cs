using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretIdleState : TurretStateBase
{
    public TurretIdleState(Turret turret, ITurretStateService turretStateService) : base(turret, turretStateService)
    {
    }
}
