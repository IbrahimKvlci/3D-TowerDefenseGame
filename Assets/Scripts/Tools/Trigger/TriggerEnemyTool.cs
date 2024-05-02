using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class TriggerEnemyTool
{
    public static List<Enemy> GetAllTriggeredEnemies(Transform transform, float range, LayerMask layerMask)
    {
        List<Enemy> result = new List<Enemy>();
        List<Collider> triggeredEnemiesCollider = Physics.OverlapSphere(transform.transform.position, range, layerMask).ToList();

        foreach (var enemy in triggeredEnemiesCollider)
        {
            result.Add(enemy.GetComponent<Enemy>());
        }

        return result;
    }
}
