using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class Turret : PlayerObjectProduct
{
    [field:SerializeField] public TurretTrigger TurretTrigger { get; set; }

    public ITurretStateService TurretStateService { get; set; }

    public ITurretState TurretFireState { get; set; }
    public ITurretState TurretFreezingState { get; set; }
    public ITurretState TurretIdleState { get; set; }
    public ITurretState TurretTargetState { get; set; }

    private protected ITurretAttackService _turretAttackService;
    private protected ITurretTriggerService _turretTriggerService;


    [Inject]
    public void Construct(ITurretWorkingService turretWorkingService,ITurretAttackService turretAttackService,ITurretTriggerService turretTriggerService)
    {
        PlayerObjectWorkingService = turretWorkingService;
        _turretAttackService = turretAttackService;
        _turretTriggerService = turretTriggerService;
    }


    protected override void Awake()
    {
        base.Awake();
        TurretStateService = new TurretStateManager();
        TurretFireState = new TurretFireState(this, TurretStateService,_turretAttackService,_turretTriggerService);
        TurretFreezingState = new TurretFreezingState(this, TurretStateService);
        TurretIdleState = new TurretIdleState(this, TurretStateService);
        TurretTargetState = new TurretTargetState(this, TurretStateService,_turretTriggerService);
    }

    protected override void Start()
    {
        TurretStateService.Initialize(TurretFreezingState);

        base.Start();

    }

    protected override void Update()
    {
        base.Update();

        TurretStateService.CurrentTurretState.UpdateState();
    }

}
