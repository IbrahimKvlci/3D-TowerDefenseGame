using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRadarRocketLauncherAttackService
{
    void Attack(RadarRocketLauncher radarRocketLauncher, Enemy enemy);
}
