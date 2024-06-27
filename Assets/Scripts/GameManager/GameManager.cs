using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<MineObjectTrader> MineObjectTraderList { get; set; }
    public int Day { get; set; } = 0;

    private ITradingMineObjectService _tradingMineObjectService;

    private void Awake()
    {
        _tradingMineObjectService = TradingIoC.Instance.TradingMineObjectService;

        MineObjectTraderList = new List<MineObjectTrader> { GoldTrader.Instance};
    }

    public void NextDay() 
    {
        Day++;
        foreach (var mineObjectTrader in MineObjectTraderList)
        {
            _tradingMineObjectService.SetMineObjectTraderNextDay(mineObjectTrader);
        }
    }

}
