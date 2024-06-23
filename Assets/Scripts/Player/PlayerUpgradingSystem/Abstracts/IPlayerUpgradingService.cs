using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerUpgradingService
{
    void UpgradeMiningSpeed(Player player,int price, float multiplier = 1);
    void UpgradeObjectDamage(Player player, int price, float multiplier = 1);
    void UpgradeMineScannerSpeed(Player player,int price, float multiplier = 1);
    void UpgradePlacingSpeed(Player player, int price, float multiplier = 1);

}
