using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class TradingController : MonoBehaviour
{
    [SerializeField] private float percentRange;
    [SerializeField] private Player player;

    private ITradingMineObjectService _tradingMineObjectService;

    [Inject]
    public void Construct(ITradingMineObjectService tradingMineObjectService)
    {
        _tradingMineObjectService = tradingMineObjectService;
    }

    private void Start()
    {
        _tradingMineObjectService.SetRandomMineObjectPriceUSDParityPercently((MineObject)player.PlayerShopping.MineObjects[0],percentRange);
    }
}
