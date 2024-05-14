using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerUpgradingService
{
    void UpgradeMiningSpeed(Player player,float multiplier,int price);
    void UpgradeObjectDamage(Player player, float multiplier, int price);
    void UpgradeMineScannerSpeed(Player player,float multiplier, int price);
    void UpgradePlacingSpeed(Player player, float multiplier, int price);

}
