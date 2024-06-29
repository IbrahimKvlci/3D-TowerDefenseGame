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

    public void DestroyMineScanner(MineScanner mineScanner)
    {
        GameObject.Destroy(mineScanner.gameObject);
    }

    public void SetMinePointToScanner(MineScanner mineScanner, List<MinePoint> minePointList)
    {
        MinePoint minePoint = _minePointService.GetRandomMinePointFromList(minePointList);
        mineScanner.MinePoint = minePoint;
        if(minePoint != null )
            minePoint.MineScanner= mineScanner; 
    }
}
