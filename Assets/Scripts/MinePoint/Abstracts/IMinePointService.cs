using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMinePointService
{
    void SetMinePointList(List<MinePoint> pointList,List<MinePoint> minePointList,int count);
    void SetRandomMineCount(MinePoint minePoint, float minCount, float maxCount);

    MinePoint GetRandomMinePointFromList(List<MinePoint> minePointList);
}
