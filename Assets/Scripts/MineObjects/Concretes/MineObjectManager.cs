using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObjectManager : IMineObjectService
{
    public void GiveCollectedMineObjectToPlayer(MineObject mineObject, Player player)
    {
        Debug.Log(mineObject.CurrentCollectedCount);
        player.PlayerShopping.GetMineObjectFromListByObject(mineObject).Count += mineObject.CurrentCollectedCount;
        Debug.Log(player.PlayerShopping.GetMineObjectFromListByObject(mineObject).Count);
    }

    public void ResetMineObjectCurrentCount(MineObject mineObject)
    {
        mineObject.CurrentCollectedCount = 0;
    }
}
