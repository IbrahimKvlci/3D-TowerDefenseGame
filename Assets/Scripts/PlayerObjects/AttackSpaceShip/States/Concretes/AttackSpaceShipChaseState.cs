using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipChaseState : AttackSpaceShipStateBase
{
    public AttackSpaceShipChaseState(AttackSpaceShip attackSpaceShip, IAttackSpaceShipStateService attackSpaceShipStateService) : base(attackSpaceShip, attackSpaceShipStateService)
    {
    }
}
