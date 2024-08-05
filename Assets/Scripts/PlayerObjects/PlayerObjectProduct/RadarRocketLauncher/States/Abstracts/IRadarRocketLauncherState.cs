using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRadarRocketLauncherStateService
{
    public IRadarRocketLauncherState CurrentRadarRocketLauncherState { get; set; }

    void Initialize(IRadarRocketLauncherState state);
    void SwitchState(IRadarRocketLauncherState state);
}
