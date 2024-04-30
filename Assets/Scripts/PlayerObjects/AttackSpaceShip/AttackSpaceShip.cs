using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AttackSpaceShip : PlayerObject
{
    public IAttackSpaceShipState AttackSpaceShipAttackState { get; set; }
    public IAttackSpaceShipState AttackSpaceShipChaseState { get; set; }
    public IAttackSpaceShipState AttackSpaceShipFreezingState { get; set; }
    public IAttackSpaceShipState AttackSpaceShipIdleState { get; set; }

    private IAttackSpaceShipMovementService _attackSpaceShipMovementService;
    private IAttackSpaceShipStateService _attackSpaceShipStateService;

    [Inject]
    public void Construct(IAttackSpaceShipMovementService attackSpaceShipMovementService)
    {
        _attackSpaceShipMovementService = attackSpaceShipMovementService;
    }

    protected override void Awake()
    {
        base.Awake();

        _attackSpaceShipStateService = new AttackSpaceShipStateManager();

        AttackSpaceShipAttackState = new AttackSpaceShipAttackState(this,_attackSpaceShipStateService);
        AttackSpaceShipChaseState = new AttackSpaceShipChaseState(this, _attackSpaceShipStateService);
        AttackSpaceShipFreezingState = new AttackSpaceShipFreezingState(this, _attackSpaceShipStateService);
        AttackSpaceShipIdleState = new AttackSpaceShipIdleState(this, _attackSpaceShipStateService,_attackSpaceShipMovementService);

    }

    protected override void Start()
    {
        base.Start();
        Debug.Log(AttackSpaceShipIdleState);

        _attackSpaceShipStateService.Initialize(AttackSpaceShipIdleState);
    }

    protected override void Update()
    {
        base.Update();

        _attackSpaceShipStateService.CurrentAttackSpaceShipState.UpdateState();
    }


}
