using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretTriggerService
{
    Enemy GetTriggeredEnemy(TurretTriggerController turretTriggerController, float range,LayerMask layerMask);
}
