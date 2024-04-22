using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Turret : PlayerObject
{

    public ITurretStateService TurretStateService { get; set; }

    public ITurretState TurretFireState { get; set; }
    public ITurretState TurretFreezingState { get; set; }
    public ITurretState TurretIdleState { get; set; }
    public ITurretState TurretTargetState { get; set; }

    [Inject]
    public void Construct(IMineWorkingService mineWorkingService)
    {
        PlayerObjectWorkingService = mineWorkingService;
    }


    protected override void Awake()
    {
        base.Awake();
        TurretStateService = new TurretStateManager();
        TurretFireState = new TurretFireState(this, TurretStateService);
        TurretFreezingState = new TurretFreezingState(this, TurretStateService);
        TurretIdleState = new TurretIdleState(this, TurretStateService);
        TurretTargetState = new TurretTargetState(this, TurretStateService);
    }

}
