using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScannerManager : IMineScannerService
{
    private readonly IMinePointService _minePointService;
    public MineScannerManager(IMinePointService minePointService)
    {
        _minePointService = minePointService;
    }

    

    public void SetMinePointToScanner(MineScanner mineScanner, List<MinePoint> minePointList)
    {
        mineScanner.MinePoint = _minePointService.GetRandomMinePointFromList(minePointList);
    }
}
