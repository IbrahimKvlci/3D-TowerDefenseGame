using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AttackSpaceShipTriggerManger : IAttackSpaceShipTriggerService
{
    public Enemy GetTriggeredEnemy(AttackSpaceShip attackSpaceShip, LayerMask layerMask)
    {
        return TriggerEnemyTool.GetAllTriggeredEnemies(attackSpaceShip.transform, ((AttackSpaceShipSO)attackSpaceShip.PlayerObjectSO).targetRange, layerMask).Count > 0 ? TriggerEnemyTool.GetAllTriggeredEnemies(attackSpaceShip.transform, ((AttackSpaceShipSO)attackSpaceShip.PlayerObjectSO).targetRange, layerMask)[0] : null;
    }

    public bool IsEnemyStillTriggeredInTargetRange(AttackSpaceShip attackSpaceShip, Enemy enemy)
    {
        return TriggerEnemyTool.GetAllTriggeredEnemies(attackSpaceShip.transform, ((AttackSpaceShipSO)attackSpaceShip.PlayerObjectSO).targetRange, attackSpaceShip.AttackSpaceShipTrigger.LayerMask).Contains(enemy);
    }

    public bool IsEnemyTriggeredToBeAttacked(AttackSpaceShip attackSpaceShip, Enemy enemy)
    {
        return TriggerEnemyTool.GetAllTriggeredEnemies(attackSpaceShip.transform,((AttackSpaceShipSO)attackSpaceShip.PlayerObjectSO).attackRange,attackSpaceShip.AttackSpaceShipTrigger.LayerMask).Contains(enemy);
    }
}
