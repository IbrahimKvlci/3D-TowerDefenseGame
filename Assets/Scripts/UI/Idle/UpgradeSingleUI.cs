using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UpgradeSingleUI : MonoBehaviour
{

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI levelTitle;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button upgradeBtn;
    [SerializeField] private Player player;

    private PlayerUpgradeSO playerUpgradeSO;
    private int price;

    private IShoppingUpgradeService _shoppingUpgradeService;

    [Inject]
    public void Construct(IShoppingUpgradeService shoppingUpgradeService)
    {
        _shoppingUpgradeService = shoppingUpgradeService;
    }

    private void Awake()
    {
        //player = Player.Instance;

        upgradeBtn.onClick.AddListener(() =>
        {
            _shoppingUpgradeService.Upgrade(player, playerUpgradeSO, price);
            SetUpgrade(playerUpgradeSO, player);
        });
    }

    public void SetUpgrade(PlayerUpgradeSO playerUpgradeSO, Player player)
    {
        this.playerUpgradeSO = playerUpgradeSO;

        icon.sprite = playerUpgradeSO.icon;
        title.text = playerUpgradeSO.text;

        switch (playerUpgradeSO.PlayerUpgradeEnum)
        {
            case PlayerUpgrading.PlayerUpgradeEnum.MiningSpeed:

                if (playerUpgradeSO.levelPrices.Length + 1 == player.PlayerUpgrading.MiningSpeedMultiplier)
                {
                    levelTitle.text = "Max Level";
                    priceText.text = "Max";
                    price = 10000000;

                    upgradeBtn.interactable = false;
                    break;
                }

                levelTitle.text = $"Level {player.PlayerUpgrading.MiningSpeedMultiplier}";
                priceText.text = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.MiningSpeedMultiplier - 1].ToString();
                price = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.MiningSpeedMultiplier - 1];

                break;
            case PlayerUpgrading.PlayerUpgradeEnum.Damage:

                if (playerUpgradeSO.levelPrices.Length + 1 == player.PlayerUpgrading.ObjectDamageMultiplier)
                {
                    levelTitle.text = "Max Level";
                    priceText.text = "Max";
                    price = 10000000;

                    upgradeBtn.interactable = false;
                    break;
                }

                levelTitle.text = $"Level {player.PlayerUpgrading.ObjectDamageMultiplier}";
                priceText.text = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.ObjectDamageMultiplier - 1].ToString();
                price = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.ObjectDamageMultiplier - 1];

                break;
            case PlayerUpgrading.PlayerUpgradeEnum.MineScannerSpeed:

                if (playerUpgradeSO.levelPrices.Length + 1 == player.PlayerUpgrading.MineScannerSpeedMultiplier)
                {
                    levelTitle.text = "Max Level";
                    priceText.text = "Max";
                    price = 10000000;

                    upgradeBtn.interactable = false;
                    break;
                }

                levelTitle.text = $"Level {player.PlayerUpgrading.MineScannerSpeedMultiplier}";
                priceText.text = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.MineScannerSpeedMultiplier - 1].ToString();
                price = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.MineScannerSpeedMultiplier - 1];

                break;
            case PlayerUpgrading.PlayerUpgradeEnum.PlacingSpeed:

                if (playerUpgradeSO.levelPrices.Length + 1 == player.PlayerUpgrading.PlacingSpeedMultiplier)
                {
                    levelTitle.text = "Max Level";
                    priceText.text = "Max";
                    price = 10000000;

                    upgradeBtn.interactable = false;
                    break;
                }

                levelTitle.text = $"Level {player.PlayerUpgrading.PlacingSpeedMultiplier}";
                priceText.text = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.PlacingSpeedMultiplier - 1].ToString();
                price = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.PlacingSpeedMultiplier - 1];

                break;
            default:
                break;
        }

    }

    public class Factory : PlaceholderFactory<UpgradeSingleUI> { }
}
