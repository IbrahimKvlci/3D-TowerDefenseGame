using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITradingMineObjectService
{
    void SetMineObjectPriceUSDParityPercently(MineObjectTrader mineObjectTrader, float percent);
    void SetRandomMineObjectPriceUSDParityPercently(MineObjectTrader mineObjectTrader, float percentRange);
    void SetMineObjectTraderNextDay(MineObjectTrader mineObjectTrader);
    void SetMineObjectPriceUSDParityAccordingToEvent(MineObjectTrader mineObjectTrader);
    void SetMineObjectPriceUSDParityAccordingToSupplyDemand(MineObjectTrader mineObjectTrader);
    void SellMineObject<T>(MineObjectTrader mineObjectTrader, Player player,float sellingCount);
    void SellMineObject(MineObjectTrader mineObjectTrader,MineObject mineObject, Player player, float sellingCount);

    MineObjectTrader GetMineObjectTraderByMineObject(List<MineObjectTrader> mineObjectTraderList, MineObject mineObject);
}
