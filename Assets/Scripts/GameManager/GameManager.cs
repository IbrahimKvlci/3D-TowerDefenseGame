using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<MineObjectTrader> MineObjectTraderList { get; set; }
    public int Day { get; set; }

    private ITradingMineObjectService _tradingMineObjectService;

    public static GameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        _tradingMineObjectService = TradingIoC.Instance.TradingMineObjectService;

        MineObjectTraderList = MineObjectTraderContainer.Instance.MineObjectTraderList;
    }

    private void Start()
    {
        Day = 1;
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
