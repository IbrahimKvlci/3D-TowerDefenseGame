using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TradingMineObjectManager : ITradingMineObjectService
{
    public void SellMineObject<T>( Player player,float sellingCount,float price)
    {
        if (player.PlayerShopping.GetMineObjectFromListByType<T>().Count >= sellingCount)
        {
            player.PlayerShopping.Cash += (int)(sellingCount * price);
            player.PlayerShopping.GetMineObjectFromListByType<T>().Count-=sellingCount;
        }
    }

    public void SetMineObjectPriceUSDParityPercently(MineObjectTrader mineObjectTrader, float percent)
    {
        mineObjectTrader.USDParity += mineObjectTrader.USDParity * percent / 100;
    }

    public void SetRandomMineObjectPriceUSDParityPercently(MineObjectTrader mineObjectTrader, float percentRange)
    {
        float randomPercent=Random.Range(-percentRange, percentRange);
        SetMineObjectPriceUSDParityPercently(mineObjectTrader, randomPercent);
    }
}
