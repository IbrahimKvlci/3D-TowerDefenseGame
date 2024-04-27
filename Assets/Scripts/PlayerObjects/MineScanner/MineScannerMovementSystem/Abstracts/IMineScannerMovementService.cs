using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMineScannerMovementService
{
    void MoveToPoint(MineScanner mineScanner,Transform point,float speed);
    bool CheckMineScannerAtPoint(MineScanner mineScanner,Transform point);
    List<MinePoint> CreateScannerPath(MineScanner mineScanner, List<MinePoint> pointList, int minPointCount, int maxPointCount);
}
