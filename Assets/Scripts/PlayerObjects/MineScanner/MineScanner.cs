using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MineScanner : PlayerObject
{
    public MinePoint MinePoint {  get; set; }

    [field:SerializeField] public MinePointController MinePointController {  get; set; }
    [field:SerializeField] public MineScannerMovementController MineScannerMovementController {  get; set; } 

    private IMineScannerService _mineScannerService;
    private IMineScannerMovementService _mineScannerMovementService;

    [Inject]
    public void Construct(IMineScannerService mineScannerService,IMineScannerMovementService mineScannerMovementService)
    {
        _mineScannerService = mineScannerService;
        _mineScannerMovementService = mineScannerMovementService;
    }

    protected override void Start()
    {
        base.Start();

        _mineScannerService.SetMinePointToScanner(this, MinePointController.MinePointList);
        MineScannerMovementController.MinePointPath = _mineScannerMovementService.CreateScannerPath(this, MinePointController.PointList, 3, 6);
    }
}
