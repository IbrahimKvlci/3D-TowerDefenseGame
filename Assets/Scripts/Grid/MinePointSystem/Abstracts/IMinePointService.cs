using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMinePointService
{
    void SetMinePointList(List<MinePoint> pointList,List<MinePoint> minePointList,int count);
    MinePoint GetRandomMinePointFromList(List<MinePoint> minePointList);
    bool IsMineAtMinePoint();
}
