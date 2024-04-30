using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipFreezingState : AttackSpaceShipStateBase
{
    public AttackSpaceShipFreezingState(AttackSpaceShip attackSpaceShip, IAttackSpaceShipStateService attackSpaceShipStateService) : base(attackSpaceShip, attackSpaceShipStateService)
    {
    }
}
