using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackSpaceShipTriggerService
{
    Enemy GetTriggeredEnemy(AttackSpaceShip attackSpaceShip,LayerMask layerMask);

    bool IsEnemyTriggeredToBeAttacked(AttackSpaceShip attackSpaceShip,Enemy enemy);
    bool IsEnemyStillTriggeredInTargetRange(AttackSpaceShip attackSpaceShip,Enemy enemy);
}
