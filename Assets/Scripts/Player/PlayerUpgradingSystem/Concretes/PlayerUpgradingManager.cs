using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradingManager : IPlayerUpgradingService
{


    public void UpgradeMineScannerSpeed(Player player, int price, float multiplier = 1)
    {

            player.PlayerUpgrading.MineScannerSpeedMultiplier+=multiplier;

    }

    public void UpgradeMiningSpeed(Player player,  int price,float multiplier= 1)
    {

            player.PlayerUpgrading.MiningSpeedMultiplier += multiplier;

    }

    public void UpgradeObjectDamage(Player player, int price, float multiplier = 1)
    {

            player.PlayerUpgrading.ObjectDamageMultiplier += multiplier;

    }

    public void UpgradePlacingSpeed(Player player, int price, float multiplier = 1)
    {

            player.PlayerUpgrading.PlacingSpeedMultiplier += multiplier;

    }
}
