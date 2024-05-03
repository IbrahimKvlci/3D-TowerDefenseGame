using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Mine : PlayerObjectProduct
{
    [field:SerializeField] public MineObject MineObject { get; set; }
    [field:SerializeField] public MinePoint MinePoint { get; set; }
    [field:SerializeField] public LayerMask LayerMask { get; set; }

    public IMineStateService MineStateService { get; set; }

    public IMineState MineFreezingState { get; set; }
    public IMineState MineMiningState { get; set; }
    public IMineState MineIdleState { get; set; }

    private IMineTriggerService _mineTriggerService;

    [Inject]
    public void Construct(IMineWorkingService mineWorkingService,IMineTriggerService mineTriggerService)
    {
        PlayerObjectWorkingService= mineWorkingService;
        _mineTriggerService= mineTriggerService;    
    }

    protected override void Awake()
    {
        base.Awake();
        MineStateService = new MineStateManager();

        MineFreezingState = new MineFreezingState(this, MineStateService);
        MineMiningState=new MineMiningState(this,MineStateService);
        MineIdleState = new MineIdleState(this, MineStateService,_mineTriggerService);

    }

    protected override void Start()
    {
        MineStateService.Initialize(MineFreezingState);
        base.Start();

    }

    protected override void Update()
    {
        base.Update();
        MineStateService.CurrentMineState.UpdateState();
    }
}
