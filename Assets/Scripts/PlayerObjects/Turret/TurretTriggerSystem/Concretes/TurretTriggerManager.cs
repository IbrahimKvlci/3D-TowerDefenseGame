using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretTriggerManager : ITurretTriggerService
{
    public Enemy GetTriggeredEnemy(TurretTrigger turretTriggerController,float range, LayerMask layerMask)
    {
        return GetAllTriggeredEnemies(turretTriggerController,range,layerMask).Count>0? GetAllTriggeredEnemies(turretTriggerController, range, layerMask)[0]:null;
    }

    public bool IsEnemyStillTriggered(TurretTrigger turretTrigger,Enemy enemy, float range, LayerMask layerMask)
    {
        return GetAllTriggeredEnemies(turretTrigger,range,layerMask).Contains(enemy);
    }

    private List<Enemy> GetAllTriggeredEnemies(TurretTrigger turretTrigger,float range,LayerMask layerMask)
    {
        List<Enemy> result = new List<Enemy>();
        List<Collider> triggeredEnemiesCollider = Physics.OverlapSphere(turretTrigger.transform.position, range, layerMask).ToList();

        foreach (var enemy in triggeredEnemiesCollider)
        {
            result.Add(enemy.GetComponent<Enemy>());
        }

        return result;
    }
}
