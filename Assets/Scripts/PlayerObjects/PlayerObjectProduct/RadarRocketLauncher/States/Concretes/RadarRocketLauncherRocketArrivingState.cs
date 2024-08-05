using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherRocketArrivingState : RadarRocketLauncherStateBase
{
    public event EventHandler OnAttacked;


    private IRadarRocketLauncherAttackService _radarRocketLauncherAttackService;

    private float timer;

    public RadarRocketLauncherRocketArrivingState(RadarRocketLauncher radarRocketLauncher, IRadarRocketLauncherStateService radarRocketLauncherStateService,IRadarRocketLauncherAttackService radarRocketLauncherAttackService) : base(radarRocketLauncher, radarRocketLauncherStateService)
    {
        _radarRocketLauncherAttackService = radarRocketLauncherAttackService;
    }

    public override void EnterState()
    {
        base.EnterState();
        timer = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        timer+= Time.deltaTime;
        if (timer >= ((RadarRocketLauncherSO)_radarRocketlauncher.PlayerObjectSO).rocketArrivalTime)
        {
            timer = 0;
            _radarRocketLauncherAttackService.Attack(_radarRocketlauncher, _radarRocketlauncher.RadarRocketLauncherTriggerController.TargetEnemy);

            OnAttacked?.Invoke(this, EventArgs.Empty);  
            Debug.Log($"{_radarRocketlauncher.RadarRocketLauncherTriggerController.TargetEnemy.name} was damaged");
            _radarRocketLauncherStateService.SwitchState(_radarRocketlauncher.RadarRocketLauncherScanningState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

}
