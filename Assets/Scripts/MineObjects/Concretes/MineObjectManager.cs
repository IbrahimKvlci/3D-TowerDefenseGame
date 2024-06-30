using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObjectManager : IMineObjectService
{
    public void GiveCollectedMineObjectToPlayer(MineObject mineObject, Player player)
    {
        player.PlayerShopping.GetMineObjectFromListByObject(mineObject).Count += mineObject.CurrentCollectedCount;
    }

    public void ResetMineObjectCurrentCount(MineObject mineObject)
    {
        mineObject.CurrentCollectedCount = 0;
    }
}
