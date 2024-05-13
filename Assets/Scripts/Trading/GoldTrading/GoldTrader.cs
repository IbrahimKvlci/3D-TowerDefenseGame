using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GoldTrader : MineObjectTrader
{
    [SerializeField] private Player player;
    private ITradingMineObjectService _tradingMineObjectService;

    [Inject]
    public void Construct(ITradingMineObjectService tradingMineObjectService)
    {
        _tradingMineObjectService = tradingMineObjectService;
    }


    private void Start()
    {
        _tradingMineObjectService.SetRandomMineObjectPriceUSDParityPercently(this, 10);
        player.PlayerShopping.GetMineObjectFromListByType<Gold>().Count = 100;
        _tradingMineObjectService.SellMineObject<Gold>(player, 30,USDParity);
    }
}
