using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    public List<MineObjectTrader> MineObjectTraderList { get; set; }
    public int Day { get; set; } = 0;

    private ITradingMineObjectService _tradingMineObjectService;

    [Inject]
    public void Construct(ITradingMineObjectService tradingMineObjectService)
    {
        _tradingMineObjectService = tradingMineObjectService;
    }

    private void Awake()
    {
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
