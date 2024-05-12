using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITradingMineObjectService
{
    void SetMineObjectPriceUSDParityPercently(MineObject mineObject,float percent);
    void SetRandomMineObjectPriceUSDParityPercently(MineObject mineObject, float percentRange);

}
