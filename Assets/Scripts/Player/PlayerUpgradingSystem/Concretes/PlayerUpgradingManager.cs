using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradingManager : IPlayerUpgradingService
{
    private IPlayerShoppingService _playerShoppingService;

    public PlayerUpgradingManager(IPlayerShoppingService playerShoppingService)
    {
        _playerShoppingService=playerShoppingService;
    }

    public void UpgradeMineScannerSpeed(Player player, float multiplier, int price)
    {
        if (_playerShoppingService.CheckPlayerCash(player,price))
        {
            _playerShoppingService.Purchase(player, price);
            player.PlayerUpgrading.MineScannerSpeedMultiplier=multiplier;
        }
    }

    public void UpgradeMiningSpeed(Player player, float multiplier, int price)
    {
        if (_playerShoppingService.CheckPlayerCash(player, price))
        {
            _playerShoppingService.Purchase(player, price);
            player.PlayerUpgrading.MiningSpeedMultiplier = multiplier;
        }
    }

    public void UpgradeObjectDamage(Player player, float multiplier, int price)
    {
        if (_playerShoppingService.CheckPlayerCash(player, price))
        {
            _playerShoppingService.Purchase(player, price);
            player.PlayerUpgrading.ObjectDamageMultiplier = multiplier;
        }
    }

    public void UpgradePlacingSpeed(Player player, float multiplier, int price)
    {
        if (_playerShoppingService.CheckPlayerCash(player, price))
        {
            _playerShoppingService.Purchase(player, price);
            player.PlayerUpgrading.PlacingSpeedMultiplier = multiplier;
        }
    }
}
