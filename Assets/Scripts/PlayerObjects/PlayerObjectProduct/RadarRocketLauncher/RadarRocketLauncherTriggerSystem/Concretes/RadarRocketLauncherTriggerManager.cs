using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherTriggerManager : IRadarRocketLauncherTriggerService
{
    public Enemy GetTriggeredEnemy(RadarRocketLauncher radarRocketLauncher,LayerMask layerMask)
    {
        return TriggerEnemyTool.GetAllTriggeredEnemies(radarRocketLauncher.transform, ((RadarRocketLauncherSO)radarRocketLauncher.PlayerObjectSO).triggerRange, layerMask).Count > 0 ? TriggerEnemyTool.GetAllTriggeredEnemies(radarRocketLauncher.transform, ((RadarRocketLauncherSO)radarRocketLauncher.PlayerObjectSO).triggerRange, layerMask)[0] : null;
    }

    public bool IsEnemyStillTriggered(RadarRocketLauncher radarRocketLauncher, Enemy enemy ,LayerMask layerMask)
    {
        return TriggerEnemyTool.GetAllTriggeredEnemies(radarRocketLauncher.transform, ((RadarRocketLauncherSO)radarRocketLauncher.PlayerObjectSO).triggerRange, layerMask).Contains(enemy);
    }
}
