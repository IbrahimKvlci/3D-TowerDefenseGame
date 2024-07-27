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
        float total=Player.Instance.PlayerShopping.GetMineObjectFromListByObject(mineObjectTrader.MineObject).Count;
        float percent = (-mineObjectTrader.SellingCountEachDay / (total + mineObjectTrader.SellingCountEachDay))*100;

        if(percent ==0)
        {
            SetMineObjectPriceUSDParityPercently(mineObjectTrader, 20);
        }
        else if(percent == -100)
        {
            SetMineObjectPriceUSDParityPercently(mineObjectTrader, -20);
        }
        else if (percent > -50)
        {
            SetMineObjectPriceUSDParityPercently(mineObjectTrader, -5f);
        }
        else if(percent<=-50)
        {
            SetMineObjectPriceUSDParityPercently(mineObjectTrader, -15f);
        }
    }

    public void SetMineObjectPriceUSDParityPercently(MineObjectTrader mineObjectTrader, float percent)
    {
        mineObjectTrader.USDParity += mineObjectTrader.USDParity * percent/100;
    }

    public void SetRandomMineObjectPriceUSDParityPercently(MineObjectTrader mineObjectTrader, float percentRange)
    {
        float randomPercent;
        float currentPrice = mineObjectTrader.USDParity;
        float startingPrice=mineObjectTrader.MineObject.MineObjectSO.startingPrice;

        float startingPriceCurrentPricePercent = (currentPrice - startingPrice) / startingPrice * 100;

        if (startingPriceCurrentPricePercent >= 50)
        {
            randomPercent = Random.Range(-percentRange * 2, percentRange / 2);
        }
        else if(-startingPriceCurrentPricePercent >= 50)
        {
            randomPercent = Random.Range(-percentRange / 2, percentRange * 2);

        }
        else
        {
            randomPercent = Random.Range(-percentRange, percentRange);
        }

        SetMineObjectPriceUSDParityPercently(mineObjectTrader, randomPercent);
    }

    public void SetMineObjectTraderNextDay(MineObjectTrader mineObjectTrader)
    {
        SetMineObjectPriceUSDParityAccordingToSupplyDemand(mineObjectTrader);
        SetRandomMineObjectPriceUSDParityPercently(mineObjectTrader, 20);
        mineObjectTrader.PriceHistory.Add(mineObjectTrader.USDParity);
        ResetMineObjectTrader(mineObjectTrader);
    }

    private void ResetMineObjectTrader(MineObjectTrader mineObjectTrader)
    {
        mineObjectTrader.SellingCountEachDay = 0;
    }

    public void SellMineObject(MineObjectTrader mineObjectTrader,MineObject mineObject, Player player, float sellingCount)
    {
        if (player.PlayerShopping.GetMineObjectFromListByObject(mineObject).Count >= sellingCount)
        {
            player.PlayerShopping.Cash += sellingCount * mineObjectTrader.USDParity;
            player.PlayerShopping.GetMineObjectFromListByObject(mineObject).Count -= sellingCount;
            mineObjectTrader.SellingCountEachDay += sellingCount;
        }
    }

    public MineObjectTrader GetMineObjectTraderByMineObject(List<MineObjectTrader> mineObjectTraderList,MineObject mineObject)
    {
        return mineObjectTraderList.FirstOrDefault(obj => obj.MineObject.GetType() == mineObject.GetType());

    }
}
