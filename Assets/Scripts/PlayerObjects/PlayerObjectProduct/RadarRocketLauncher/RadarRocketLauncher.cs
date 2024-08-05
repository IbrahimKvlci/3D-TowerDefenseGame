using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncher : PlayerObjectProduct
{
    [field:SerializeField] public RadarRocketLauncherTriggerController RadarRocketLauncherTriggerController { get; set; }
    [field: SerializeField] public GameObject RocketPrefab { get; set; }

    public GameObject Rocket { get; set; }

    public IRadarRocketLauncherState RadarRocketLauncherFreezingState { get; set; }
    public IRadarRocketLauncherState RadarRocketLauncherScanningState { get; set; }
    public IRadarRocketLauncherState RadarRocketLauncherRocketArrivingState { get; set; }
    public IRadarRocketLauncherState RadarRocketLauncherRocketCreatingState { get; set; }

    private IRadarRocketLauncherStateService _radarRocketLauncherStateService;
    private IRadarRocketLauncherTriggerService _radarRocketLauncherTriggerService;
    private IRadarRocketLauncherAttackService _radarRocketLauncherAttackService;

    protected override void Awake()
    {
        base.Awake();

        _radarRocketLauncherTriggerService = InGameIoC.Instance.RadarRocketLauncherTriggerService;
        _radarRocketLauncherAttackService = InGameIoC.Instance.RadarRocketLauncherAttackService;

        _radarRocketLauncherStateService = new RadarRocketLauncherStateManager();

        RadarRocketLauncherFreezingState = new RadarRocketLauncherFreezingState(this, _radarRocketLauncherStateService);
        RadarRocketLauncherScanningState = new RadarRocketLauncherScanningState(this, _radarRocketLauncherStateService,_radarRocketLauncherTriggerService);
        RadarRocketLauncherRocketArrivingState = new RadarRocketLauncherRocketArrivingState(this, _radarRocketLauncherStateService,_radarRocketLauncherAttackService);
        RadarRocketLauncherRocketCreatingState = new RadarRocketLauncherRocketCreatingState(this, _radarRocketLauncherStateService);
    }

    protected override void Start()
    {
        base.Start();
        _radarRocketLauncherStateService.Initialize(RadarRocketLauncherFreezingState);
    }

    protected override void Update()
    {
        base.Update();
        _radarRocketLauncherStateService.CurrentRadarRocketLauncherState.UpdateState();
    }
}
