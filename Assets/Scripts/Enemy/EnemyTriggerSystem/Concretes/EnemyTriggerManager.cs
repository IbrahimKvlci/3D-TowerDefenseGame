using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerManager : IEnemyTriggerService
{
    public bool IsPlayerObjectTriggeredToBeAttacked(Transform transform,PlayerObject playerObject, float range, LayerMask layerMask)
    {
        if( Physics.Raycast(transform.position, transform.forward,out RaycastHit hitInfo, range, layerMask))
        {
            if (hitInfo.transform == playerObject)
            {
                return true;
            }
        }
        return false;
    }
}
