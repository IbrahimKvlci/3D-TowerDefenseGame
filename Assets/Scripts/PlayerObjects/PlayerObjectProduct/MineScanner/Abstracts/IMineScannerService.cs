using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMineScannerService
{
    void SetMinePointToScanner(MineScanner mineScanner, List<MinePoint> minePointList);
    void DestroyMineScanner(MineScanner mineScanner);
}
