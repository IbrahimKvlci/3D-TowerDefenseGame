using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretStateBase : ITurretState
{
    protected private Turret _turret;
    protected private ITurretStateService _turretStateService;

    public TurretStateBase(Turret turret,ITurretStateService turretStateService)
    {
        _turret = turret;
        _turretStateService= turretStateService;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
    }
}
