using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyTriggerService
{
    bool IsPlayerObjectTriggeredToBeAttacked(Transform transform, PlayerObject playerObject, float range, LayerMask layerMask);
}
