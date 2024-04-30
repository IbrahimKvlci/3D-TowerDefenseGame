using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipStateBase : IAttackSpaceShipState
{
    protected AttackSpaceShip _attackSpaceShip;
    protected IAttackSpaceShipStateService _attackSpaceShipStateService;

    public AttackSpaceShipStateBase(AttackSpaceShip attackSpaceShip,IAttackSpaceShipStateService attackSpaceShipStateService)
    {
        _attackSpaceShip = attackSpaceShip;
        _attackSpaceShipStateService = attackSpaceShipStateService;
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
