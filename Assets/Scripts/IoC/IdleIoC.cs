using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleIoC : MonoBehaviour
{
    public static IdleIoC Instance { get; set; }

    public IPlayerShoppingService PlayerShoppingService { get; set; }
    public IShoppingUpgradeService ShoppingUpgradeService { get; set; }
    public IPlayerUpgradingService PlayerUpgradingService { get; set; }

    private void Awake()
    {
        Instance = this;

        PlayerShoppingService = new PlayerShoppingManager();
        PlayerUpgradingService = new PlayerUpgradingManager();
        ShoppingUpgradeService = new ShoppingUpgradeManager(PlayerShoppingService, PlayerUpgradingService);

    }
}
