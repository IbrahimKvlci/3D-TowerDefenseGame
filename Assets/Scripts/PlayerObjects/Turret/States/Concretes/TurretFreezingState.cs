using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFreezingState : TurretStateBase
{
    public TurretFreezingState(Turret turret, ITurretStateService turretStateService) : base(turret, turretStateService)
    {
    }
}
