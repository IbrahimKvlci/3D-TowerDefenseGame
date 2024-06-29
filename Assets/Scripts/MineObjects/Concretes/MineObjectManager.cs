using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObjectManager : IMineObjectService
{
    public void ResetMineObjectCurrentCount(MineObject mineObject)
    {
        mineObject.CurrentCollectedCount = 0;
    }
}
