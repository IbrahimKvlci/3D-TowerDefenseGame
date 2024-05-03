using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipAttackState : AttackSpaceShipStateBase
{
    private float timer;

    private IAttackSpaceShipAttackService _attackSpaceShipAttackService;
    private IAttackSpaceShipTriggerService _attackSpaceShipTriggerService;

    public AttackSpaceShipAttackState(AttackSpaceShip attackSpaceShip, IAttackSpaceShipStateService attackSpaceShipStateService, IAttackSpaceShipAttackService attackSpaceShipAttackService,IAttackSpaceShipTriggerService attackSpaceShipTriggerService) : base(attackSpaceShip, attackSpaceShipStateService)
    {
        _attackSpaceShipAttackService = attackSpaceShipAttackService;
        _attackSpaceShipTriggerService = attackSpaceShipTriggerService;
    }

    public override void EnterState()
    {
        base.EnterState();
        timer = 0f;
    }

    public override void UpdateState()
    {
        base.UpdateState();

        timer+= Time.deltaTime;
        if (timer > ((AttackSpaceShipSO)_attackSpaceShip.PlayerObjectSO).fireDuration)
        {
            timer = 0f;
            _attackSpaceShipAttackService.Attack(_attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy, ((AttackSpaceShipSO)_attackSpaceShip.PlayerObjectSO).damage);
        }

        if (!_attackSpaceShipTriggerService.IsEnemyTriggeredToBeAttacked(_attackSpaceShip, _attackSpaceShip.AttackSpaceShipTrigger.TriggeredEnemy))
        {
            _attackSpaceShipStateService.SwitchState(_attackSpaceShip.AttackSpaceShipChaseState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }


}
