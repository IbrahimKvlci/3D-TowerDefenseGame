using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineScannerMovementManager : IMineScannerMovementService
{
    public bool CheckMineScannerAtPoint(MineScanner mineScanner, Transform point)
    {
        float minDistance = 0.5f;
        if (Vector3.Distance(mineScanner.transform.position, point.transform.position) < minDistance)
        {
            return true;
        }
        return false;
    }

    public void MoveToPoint(MineScanner mineScanner, Transform point,float speed)
    {
        Vector3 moveVector=point.position-mineScanner.transform.position;
        moveVector.y = 0;
        moveVector.Normalize();


        mineScanner.transform.forward=Vector3.Lerp(mineScanner.transform.forward, moveVector, Time.deltaTime*5);
        if (mineScanner.transform.forward == moveVector)
            mineScanner.transform.position += (mineScanner.transform.forward * Time.deltaTime * speed);
        else
            mineScanner.transform.position += (mineScanner.transform.forward * Time.deltaTime * Mathf.Lerp(0,speed,0.7f));

    }

    public List<MinePoint> CreateScannerPath(MineScanner mineScanner, List<MinePoint> pointList, int minPointCount, int maxPointCount)
    {
        List<MinePoint> pointPathList = new List<MinePoint>();

        int randomPointCount = Random.Range(minPointCount, maxPointCount);
        do
        {
            int randomPointIndex = Random.Range(0, pointList.Count);
            if (!pointPathList.Contains(pointList[randomPointIndex]))
            {
                pointPathList.Add(pointList[randomPointIndex]);
            }
        } while (pointPathList.Count < randomPointCount);

        if (mineScanner.MinePoint != null)
        {
            if (pointPathList.Contains(mineScanner.MinePoint))
            {
                pointPathList.Remove(mineScanner.MinePoint);
            }
            pointPathList.Add((mineScanner.MinePoint));
        }

        return pointPathList;
    }
}
