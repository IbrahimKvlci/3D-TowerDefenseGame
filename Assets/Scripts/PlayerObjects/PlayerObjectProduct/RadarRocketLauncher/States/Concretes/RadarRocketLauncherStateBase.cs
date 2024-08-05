using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherStateBase : IRadarRocketLauncherState
{
    protected RadarRocketLauncher _radarRocketlauncher;
    protected IRadarRocketLauncherStateService _radarRocketLauncherStateService;

    public RadarRocketLauncherStateBase(RadarRocketLauncher radarRocketLauncher,IRadarRocketLauncherStateService radarRocketLauncherStateService)
    {
        _radarRocketlauncher = radarRocketLauncher;
        _radarRocketLauncherStateService = radarRocketLauncherStateService;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
    }
}
