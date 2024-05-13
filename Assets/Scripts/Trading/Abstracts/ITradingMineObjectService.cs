using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITradingMineObjectService
{
    void SetMineObjectPriceUSDParityPercently(MineObjectTrader mineObjectTrader, float percent);
    void SetRandomMineObjectPriceUSDParityPercently(MineObjectTrader mineObjectTrader, float percentRange);
    void SellMineObject<T>(Player player,float sellingCount,float price);
}
