using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRadarRocketLauncherTriggerService 
{
    Enemy GetTriggeredEnemy(RadarRocketLauncher radarRocketLauncher,LayerMask layerMask);
    bool IsEnemyStillTriggered(RadarRocketLauncher radarRocketLauncher,Enemy enemy,LayerMask layerMask);
}
