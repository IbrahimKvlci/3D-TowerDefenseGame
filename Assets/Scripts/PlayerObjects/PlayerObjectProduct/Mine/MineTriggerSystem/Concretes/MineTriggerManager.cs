using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineTriggerManager : IMineTriggerService
{
    public bool IsMineAtMinePoint(Mine mine, LayerMask layerMask,out MinePoint minePoint)
    {
        float distance = 10f;
        if(Physics.Raycast(mine.transform.position, -mine.transform.up, out RaycastHit hitInfo,distance,layerMask))
        {
            minePoint=hitInfo.transform.GetComponent<MinePoint>();
            return true;
        }
        minePoint = null;
        return false;
        
    }
}
