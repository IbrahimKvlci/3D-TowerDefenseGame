using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipAttackState : AttackSpaceShipStateBase
{
    public AttackSpaceShipAttackState(AttackSpaceShip attackSpaceShip, IAttackSpaceShipStateService attackSpaceShipStateService) : base(attackSpaceShip, attackSpaceShipStateService)
    {
    }
}
