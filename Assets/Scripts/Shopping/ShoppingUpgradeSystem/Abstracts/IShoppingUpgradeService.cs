using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShoppingUpgradeService
{
    void Upgrade(Player player,PlayerUpgradeSO playerUpgradeSO,int price);
}
