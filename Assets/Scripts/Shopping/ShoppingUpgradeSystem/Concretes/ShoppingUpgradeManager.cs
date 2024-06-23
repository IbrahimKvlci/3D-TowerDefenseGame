using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingUpgradeManager : IShoppingUpgradeService
{
    private IPlayerShoppingService _playerShoppingService;
    private IPlayerUpgradingService _playerUpgradingService;
    public ShoppingUpgradeManager(IPlayerShoppingService playerShoppingService,IPlayerUpgradingService playerUpgradingService)
    {
        _playerShoppingService = playerShoppingService;
        _playerUpgradingService=playerUpgradingService ;
    }

    public void Upgrade(Player player, PlayerUpgradeSO playerUpgradeSO, int price)
    {
        if (_playerShoppingService.CheckPlayerCash(player, price))
        {
            switch (playerUpgradeSO.PlayerUpgradeEnum)
            {
                case PlayerUpgrading.PlayerUpgradeEnum.Damage:
                    if(playerUpgradeSO.levelPrices.Length+1>player.PlayerUpgrading.ObjectDamageMultiplier)
                        _playerUpgradingService.UpgradeObjectDamage(player, price);
                    break;
                case PlayerUpgrading.PlayerUpgradeEnum.MineScannerSpeed:
                    if (playerUpgradeSO.levelPrices.Length + 1 > player.PlayerUpgrading.MineScannerSpeedMultiplier)
                        _playerUpgradingService.UpgradeMineScannerSpeed(player, price);
                    break;
                case PlayerUpgrading.PlayerUpgradeEnum.MiningSpeed:
                    if (playerUpgradeSO.levelPrices.Length + 1 > player.PlayerUpgrading.MiningSpeedMultiplier)
                        _playerUpgradingService.UpgradeMiningSpeed(player, price);
                    break;
                case PlayerUpgrading.PlayerUpgradeEnum.PlacingSpeed:
                    if (playerUpgradeSO.levelPrices.Length + 1 > player.PlayerUpgrading.PlacingSpeedMultiplier)
                        _playerUpgradingService.UpgradePlacingSpeed(player, price);
                    break;
                default:
                    Debug.LogError("Not exist");
                    break;
            }
            _playerShoppingService.Purchase(player, price);
        }
    }
}
