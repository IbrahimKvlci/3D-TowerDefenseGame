using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretTriggerManager : ITurretTriggerService
{
    public Enemy GetTriggeredEnemy(TurretTrigger turretTriggerController,float range, LayerMask layerMask)
    {
        return TriggerEnemyTool.GetAllTriggeredEnemies(turretTriggerController.transform,range,layerMask).Count>0? TriggerEnemyTool.GetAllTriggeredEnemies(turretTriggerController.transform, range, layerMask)[0]:null;
    }

    public bool IsEnemyStillTriggered(TurretTrigger turretTrigger,Enemy enemy, float range, LayerMask layerMask)
    {
        return TriggerEnemyTool.GetAllTriggeredEnemies(turretTrigger.transform, range, layerMask).Contains(enemy);
    }

    
}
