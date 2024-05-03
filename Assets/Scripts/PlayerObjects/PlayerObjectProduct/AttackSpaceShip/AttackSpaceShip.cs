using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackSpaceShip : PlayerObjectProduct
{
    [field: SerializeField] public AttackSpaceShipTrigger AttackSpaceShipTrigger {  get; set; }

    public IAttackSpaceShipState AttackSpaceShipAttackState { get; set; }
    public IAttackSpaceShipState AttackSpaceShipChaseState { get; set; }
    public IAttackSpaceShipState AttackSpaceShipFreezingState { get; set; }
    public IAttackSpaceShipState AttackSpaceShipIdleState { get; set; }

    private IAttackSpaceShipMovementService _attackSpaceShipMovementService;
    private IAttackSpaceShipStateService _attackSpaceShipStateService;
    private IAttackSpaceShipTriggerService _attackSpaceShipTriggerService;
    private IAttackSpaceShipAttackService _attackSpaceShipAttackService;

    [Inject]
    public void Construct(IAttackSpaceShipMovementService attackSpaceShipMovementService,IAttackSpaceShipTriggerService attackSpaceShipTriggerService,IAttackSpaceShipAttackService attackSpaceShipAttackService)
    {
        _attackSpaceShipMovementService = attackSpaceShipMovementService;
        _attackSpaceShipTriggerService = attackSpaceShipTriggerService;
        _attackSpaceShipAttackService= attackSpaceShipAttackService;
    }

    protected override void Awake()
    {
        base.Awake();

        _attackSpaceShipStateService = new AttackSpaceShipStateManager();

        AttackSpaceShipAttackState = new AttackSpaceShipAttackState(this,_attackSpaceShipStateService,_attackSpaceShipAttackService,_attackSpaceShipTriggerService);
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
