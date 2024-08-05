using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherAttackManager : IRadarRocketLauncherAttackService
{
    private IEnemyHealthService _enemyHealthService;

    public RadarRocketLauncherAttackManager(IEnemyHealthService enemyHealthService)
    {
        _enemyHealthService = enemyHealthService;
    }

    public void Attack(RadarRocketLauncher radarRocketLauncher, Enemy enemy)
    {
        _enemyHealthService.TakeDamage(enemy, ((RadarRocketLauncherSO)radarRocketLauncher.PlayerObjectSO).damage);
    }
}
