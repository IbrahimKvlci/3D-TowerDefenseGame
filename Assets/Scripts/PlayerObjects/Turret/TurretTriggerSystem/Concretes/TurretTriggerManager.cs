using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretTriggerManager : ITurretTriggerService
{
    public Enemy GetTriggeredEnemy(TurretTriggerController turretTriggerController,float range, LayerMask layerMask)
    {
        return Physics.OverlapSphere(turretTriggerController.transform.position, range, layerMask).Length>0? Physics.OverlapSphere(turretTriggerController.transform.position, range, layerMask)[0].GetComponent<Enemy>():null;
    }
}
