using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScanner : PlayerObjectProduct
{
    public MinePoint MinePoint {  get; set; }

    [field:SerializeField] public MineScannerMovementController MineScannerMovementController {  get; set; } 

    private IMineScannerService _mineScannerService;
    private IMineScannerMovementService _mineScannerMovementService;


    protected override void Awake()
    {
        base.Awake();
        _mineScannerService = InGameIoC.Instance.MineScannerService;
        _mineScannerMovementService=InGameIoC.Instance.MineScannerMovementService;
    }

    protected override void Start()
    {
        base.Start();

        _mineScannerService.SetMinePointToScanner(this, MinePointController.Instance.MinePointList);
        MineScannerMovementController.MinePointPath = _mineScannerMovementService.CreateScannerPath(this, MinePointController.Instance.PointList, 3, 6);
    }
}
