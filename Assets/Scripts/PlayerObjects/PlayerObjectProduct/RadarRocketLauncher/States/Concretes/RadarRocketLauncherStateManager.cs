using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherStateManager : IRadarRocketLauncherStateService
{
    public IRadarRocketLauncherState CurrentRadarRocketLauncherState { get; set ; }

    public void Initialize(IRadarRocketLauncherState state)
    {
        CurrentRadarRocketLauncherState = state;
        state.EnterState();
    }

    public void SwitchState(IRadarRocketLauncherState state)
    {
        CurrentRadarRocketLauncherState.ExitState();
        CurrentRadarRocketLauncherState = state;
        CurrentRadarRocketLauncherState.EnterState();
    }
}
