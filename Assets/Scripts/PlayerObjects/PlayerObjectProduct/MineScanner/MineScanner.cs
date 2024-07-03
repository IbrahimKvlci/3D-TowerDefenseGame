using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScanner : PlayerObjectProduct
{
    public MinePoint MinePoint {  get; set; }

    [field:SerializeField] public MineScannerMovementController MineScannerMovementController {  get; set; }
    [field:SerializeField] public GameObject ScanParticleObject { get; set; }

    private IMineScannerService _mineScannerService;
    private IMineScannerMovementService _mineScannerMovementService;
  

    public IMineScannerState MineScannerFreezingState { get; set; }
    public IMineScannerState MineScannerIdleState { get; set; }
    public IMineScannerState MineScannerScanningState { get; set; }
    public IMineScannerState MineScannerWaitingState { get; set; }

    private IMineScannerStateService _mineScannerStateService;

    protected override void Awake()
    {
        base.Awake();
        _mineScannerService = InGameIoC.Instance.MineScannerService;
        _mineScannerMovementService=InGameIoC.Instance.MineScannerMovementService;

        _mineScannerStateService = new MineScannerStateManager();

        MineScannerFreezingState = new MineScannerFreezingState(this, _mineScannerStateService);
        MineScannerIdleState=new MineScannerIdleState(this, _mineScannerStateService,_mineScannerService);
        MineScannerScanningState = new MineScannerScanningState(this, _mineScannerStateService,_mineScannerMovementService,_mineScannerService);
        MineScannerWaitingState = new MineScannerWaitingState(this, _mineScannerStateService);
    }

    protected override void Start()
    {
        base.Start();

        _mineScannerStateService.Initialize(MineScannerFreezingState);

    }

    protected override void Update()
    {
        base.Update();
        _mineScannerStateService.CurrentMineScannerState.UpdateState();
    }
}
