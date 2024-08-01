using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<PlanetSO> planetSOList;
    [SerializeField] private float cashPerSecond;

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

    private void Update()
    {
        HandlePlayerCashPerSecond();
    }

    private void HandlePlayerCashPerSecond()
    {
        Player.Instance.PlayerShopping.Cash += cashPerSecond * Time.unscaledDeltaTime;
    }

    public void NextDay() 
    {
        Day++;
        foreach (var mineObjectTrader in MineObjectTraderList)
        {
            _tradingMineObjectService.SetMineObjectTraderNextDay(mineObjectTrader);
        }
    }

    public void EndOfTheDay()
    {
        if (!Player.Instance.PlayerWentBankrupt)
        {
            if (CheckPlayerHasMoneyBelowBankruptcy(Player.Instance))
            {
                Player.Instance.PlayerBankruptcy();
                Debug.Log("bankruptcy");
            }
        }
    }

    private bool CheckPlayerHasMoneyBelowBankruptcy(Player player)
    {
        float minMoney = planetSOList[0].price;
        foreach (PlanetSO planetSO in planetSOList)
        {
            if (minMoney > planetSO.price)
            {
                minMoney = planetSO.price;
            }
        }

        float playerTotalMoney=player.PlayerShopping.Cash;
        foreach (MineObject mineObject in player.PlayerShopping.MineObjects)
        {

            playerTotalMoney += mineObject.Count * _tradingMineObjectService.GetMineObjectTraderByMineObject(MineObjectTraderContainer.Instance.MineObjectTraderList, mineObject).USDParity;
        }

        if(playerTotalMoney < minMoney)
        {
            return true;
        }
        return false;

    }

}
