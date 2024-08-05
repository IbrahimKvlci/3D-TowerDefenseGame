using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherScanningState : RadarRocketLauncherStateBase
{
    private IRadarRocketLauncherTriggerService _radarRocketLauncherTriggerService;

    public RadarRocketLauncherScanningState(RadarRocketLauncher radarRocketLauncher, IRadarRocketLauncherStateService radarRocketLauncherStateService, IRadarRocketLauncherTriggerService radarRocketLauncherTriggerService) : base(radarRocketLauncher, radarRocketLauncherStateService)
    {
        _radarRocketLauncherTriggerService = radarRocketLauncherTriggerService;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if (_radarRocketLauncherTriggerService.GetTriggeredEnemy(_radarRocketlauncher, _radarRocketlauncher.RadarRocketLauncherTriggerController.triggerLayerMask)!=null)
        {
            _radarRocketlauncher.RadarRocketLauncherTriggerController.TargetEnemy = _radarRocketLauncherTriggerService.GetTriggeredEnemy(_radarRocketlauncher, _radarRocketlauncher.RadarRocketLauncherTriggerController.triggerLayerMask);
            _radarRocketLauncherStateService.SwitchState(_radarRocketlauncher.RadarRocketLauncherRocketCreatingState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

}
