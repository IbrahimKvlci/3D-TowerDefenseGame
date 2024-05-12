using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingMineObjectManager : ITradingMineObjectService
{
    public void SetMineObjectPriceUSDParityPercently(MineObject mineObject, float percent)
    {
        mineObject.USDParity += mineObject.USDParity * percent / 100;
    }

    public void SetRandomMineObjectPriceUSDParityPercently(MineObject mineObject, float percentRange)
    {
        float randomPercent=Random.Range(-percentRange, percentRange);
        SetMineObjectPriceUSDParityPercently(mineObject, randomPercent);
    }
}
