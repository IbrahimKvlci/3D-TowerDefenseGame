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
        } while (minePoint.IsActive);

        minePoint.IsActive = true;
        return minePoint;
    }

    public bool IsMineAtMinePoint()
    {
        throw new System.NotImplementedException();
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

}
