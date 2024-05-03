using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretTriggerService
{
    Enemy GetTriggeredEnemy(TurretTrigger turretTriggerController, float range,LayerMask layerMask);

    bool IsEnemyStillTriggered(TurretTrigger turretTrigger, Enemy enemy, float range, LayerMask layerMask);
}
