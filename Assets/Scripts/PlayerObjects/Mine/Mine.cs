using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Mine : PlayerObject
{
    [field:SerializeField] public MineObject MineObject { get; set; }

    public IMineStateService MineStateService { get; set; }

    public IMineState MineFreezingState { get; set; }
    public IMineState MineMiningState { get; set; }

    [Inject]
    public void Construct(IMineWorkingService mineWorkingService)
    {
        PlayerObjectWorkingService= mineWorkingService;
    }

    protected override void Awake()
    {
        base.Awake();
        MineStateService = new MineStateManager();

        MineFreezingState = new MineFreezingState(this, MineStateService);
        MineMiningState=new MineMiningState(this,MineStateService);
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
