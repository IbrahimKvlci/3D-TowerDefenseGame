using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFireState : TurretStateBase
{
    public TurretFireState(Turret turret, ITurretStateService turretStateService) : base(turret, turretStateService)
    {
    }
}
