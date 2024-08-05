using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherRocketCreatingState : RadarRocketLauncherStateBase
{
    public event EventHandler OnRocketCreated;

    private float timer;

    public RadarRocketLauncherRocketCreatingState(RadarRocketLauncher radarRocketLauncher, IRadarRocketLauncherStateService radarRocketLauncherStateService) : base(radarRocketLauncher, radarRocketLauncherStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        timer = 0;
        Debug.Log("create;");
    }

    public override void UpdateState()
    {
        base.UpdateState();
        timer += Time.deltaTime;
        if(timer > ((RadarRocketLauncherSO)_radarRocketlauncher.PlayerObjectSO).rocketCreatingTime)
        {
            timer= 0;
            if (_radarRocketlauncher.RadarRocketLauncherTriggerController.TargetEnemy != null)
            {
                Vector3 spawnPos = _radarRocketlauncher.RadarRocketLauncherTriggerController.TargetEnemy.transform.position;
                spawnPos.y = 100;
                Rocket rocket = GameObject.Instantiate(_radarRocketlauncher.RocketPrefab, spawnPos, Quaternion.identity).GetComponent<Rocket>();
                rocket.EnemyTarget = _radarRocketlauncher.RadarRocketLauncherTriggerController.TargetEnemy;

                //OnRocketCreated?.Invoke(this, EventArgs.Empty);
            }
            _radarRocketLauncherStateService.SwitchState(_radarRocketlauncher.RadarRocketLauncherScanningState);

        }

    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
