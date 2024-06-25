using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TradingMineObjectManager : ITradingMineObjectService
{
    

    public void SellMineObject<T>(MineObjectTrader mineObjectTrader, Player player,float sellingCount)
    {
        if (player.PlayerShopping.GetMineObjectFromListByType<T>().Count >= sellingCount)
        {
            player.PlayerShopping.Cash += (int)(sellingCount * mineObjectTrader.USDParity);
            player.PlayerShopping.GetMineObjectFromListByType<T>().Count-=sellingCount;
            mineObjectTrader.SellingCountEachDay += sellingCount;
        }
    }

    public void SetMineObjectPriceUSDParityAccordingToEvent(MineObjectTrader mineObjectTrader)
    {
        float eventPricePercant = 3f;
        SetMineObjectPriceUSDParityPercently(mineObjectTrader, eventPricePercant);
    }

    public void SetMineObjectPriceUSDParityAccordingToSupplyDemand(MineObjectTrader mineObjectTrader)
    {
        SetMineObjectPriceUSDParityPercently(mineObjectTrader, -mineObjectTrader.SellingCountEachDay / 100);
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

    public void SetMineObjectTraderNextDay(MineObjectTrader mineObjectTrader)
    {
        SetMineObjectPriceUSDParityAccordingToSupplyDemand(mineObjectTrader);
        mineObjectTrader.PriceHistory.Add(mineObjectTrader.USDParity);
        ResetMineObjectTrader(mineObjectTrader);
    }

    private void ResetMineObjectTrader(MineObjectTrader mineObjectTrader)
    {
        mineObjectTrader.SellingCountEachDay = 0;
    }
}
