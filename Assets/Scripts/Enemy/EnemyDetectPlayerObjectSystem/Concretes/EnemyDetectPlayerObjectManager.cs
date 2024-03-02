using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayerObjectManager : IEnemyDetectPlayerObjectService
{
    public bool TryGetClosestPlayerObject(Enemy enemy, List<PlayerObject> playerObjects,out PlayerObject playerObject)
    {
        if (playerObjects.Count == 0)
        {
            playerObject = null;
            return false;
        }
        PlayerObject playerObjectToFollow = playerObjects[0];
        for (int i = 1; i < playerObjects.Count; i++)
        {
            float distanceEnemyAndFirstDamageable = Vector3.Distance(enemy.transform.position, playerObjectToFollow.transform.position);
            float distanceEnemyAndSecondDamageable = Vector3.Distance(enemy.transform.position, playerObjects[i].transform.position);

            if (distanceEnemyAndSecondDamageable < distanceEnemyAndFirstDamageable)
            {
                //New closest player object was found
                playerObjectToFollow = playerObjects[i];
            }
        }

        playerObject= playerObjectToFollow;
        return true;
    }
}
