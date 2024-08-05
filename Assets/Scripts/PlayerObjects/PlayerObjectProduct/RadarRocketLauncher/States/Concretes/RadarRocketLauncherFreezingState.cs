using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherFreezingState : RadarRocketLauncherStateBase
{
    public RadarRocketLauncherFreezingState(RadarRocketLauncher radarRocketLauncher, IRadarRocketLauncherStateService radarRocketLauncherStateService) : base(radarRocketLauncher, radarRocketLauncherStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_radarRocketlauncher.IsPlaced)
        {
            _radarRocketLauncherStateService.SwitchState(_radarRocketlauncher.RadarRocketLauncherScanningState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

}
