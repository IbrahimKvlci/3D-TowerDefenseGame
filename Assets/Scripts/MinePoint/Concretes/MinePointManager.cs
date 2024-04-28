using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePointManager : IMinePointService
{
    public MinePoint GetRandomMinePointFromList(List<MinePoint> minePointList)
    {
        MinePoint minePoint;
        do
        {
            int randomIndex = Random.Range(0, minePointList.Count);
            minePoint = minePointList[randomIndex];
        } while (minePoint.IsScanned);

        minePoint.IsScanned = true;
        return minePoint;
    }


    public void SetMinePointList(List<MinePoint> pointList, List<MinePoint> minePointList, int count)
    {
        for (int i = 0; i < count; i++)
        {
            int randomIndex = Random.Range(0, pointList.Count);
            MinePoint minePoint = pointList[randomIndex];
            minePointList.Add(minePoint);
            minePoint.gameObject.SetActive(true);
        }
    }

    public void SetRandomMineCount(MinePoint minePoint, float minCount, float maxCount)
    {
        minePoint.MineCount=Random.Range(minCount, maxCount);
    }
}
