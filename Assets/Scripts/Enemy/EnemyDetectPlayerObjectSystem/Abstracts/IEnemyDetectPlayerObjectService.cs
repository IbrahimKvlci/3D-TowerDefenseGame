using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyDetectPlayerObjectService
{
    bool TryGetClosestPlayerObject(Enemy enemy, List<PlayerObject> playerObjects,out PlayerObject playerObject);
}
