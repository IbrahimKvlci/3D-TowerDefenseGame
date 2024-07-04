using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShip : PlayerObjectProduct
{
    [field: SerializeField] public AttackSpaceShipTrigger AttackSpaceShipTrigger {  get; set; }
    [field: SerializeField] public GameObject FireEngineParticleEffect { get; set; }
    [field: SerializeField] public GameObject MuzzleFlashParticleEffect { get; set; }

    public IAttackSpaceShipState AttackSpaceShipAttackState { get; set; }
    public IAttackSpaceShipState AttackSpaceShipChaseState { get; set; }
    public IAttackSpaceShipState AttackSpaceShipFreezingState { get; set; }
    public IAttackSpaceShipState AttackSpaceShipIdleState { get; set; }

    private IAttackSpaceShipMovementService _attackSpaceShipMovementService;
    private IAttackSpaceShipStateService _attackSpaceShipStateService;
    private IAttackSpaceShipTriggerService _attackSpaceShipTriggerService;
    private IAttackSpaceShipAttackService _attackSpaceShipAttackService;


    protected override void Awake()
    {
        _attackSpaceShipAttackService=InGameIoC.Instance.AttackSpaceShipAttackService;
        _attackSpaceShipTriggerService = InGameIoC.Instance.AttackSpaceShipTriggerService;
        _attackSpaceShipMovementService = InGameIoC.Instance.AttackSpaceShipMovementService;

        base.Awake();

        _attackSpaceShipStateService = new AttackSpaceShipStateManager();

        AttackSpaceShipAttackState = new AttackSpaceShipAttackState(this,_attackSpaceShipStateService,_attackSpaceShipAttackService,_attackSpaceShipTriggerService,_attackSpaceShipMovementService);
        AttackSpaceShipChaseState = new AttackSpaceShipChaseState(this, _attackSpaceShipStateService,_attackSpaceShipMovementService,_attackSpaceShipTriggerService);
        AttackSpaceShipFreezingState = new AttackSpaceShipFreezingState(this, _attackSpaceShipStateService);
        AttackSpaceShipIdleState = new AttackSpaceShipIdleState(this, _attackSpaceShipStateService,_attackSpaceShipMovementService,_attackSpaceShipTriggerService);

    }

    protected override void Start()
    {
        base.Start();

        _attackSpaceShipStateService.Initialize(AttackSpaceShipFreezingState);
    }

    protected override void Update()
    {
        base.Update();

        _attackSpaceShipStateService.CurrentAttackSpaceShipState.UpdateState();
    }


}
