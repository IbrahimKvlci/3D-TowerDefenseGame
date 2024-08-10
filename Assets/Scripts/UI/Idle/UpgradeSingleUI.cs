using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSingleUI : MonoBehaviour
{

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI title;
    [SerializeField] private TextMeshProUGUI levelTitle;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button upgradeBtn;
    [SerializeField] private Player player;

    [SerializeField] private TextMeshProUGUI upgradeTxt;

    private PlayerUpgradeSO playerUpgradeSO;
    private int price;

    private IShoppingUpgradeService _shoppingUpgradeService;


    private void Awake()
    {
        player = Player.Instance;
        _shoppingUpgradeService = IdleIoC.Instance.ShoppingUpgradeService;

        upgradeBtn.onClick.AddListener(() =>
        {
            _shoppingUpgradeService.Upgrade(player, playerUpgradeSO, price);
            SetUpgrade(playerUpgradeSO, player);
            UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.upgradeSound);

        });
    }

    public void SetUpgrade(PlayerUpgradeSO playerUpgradeSO, Player player)
    {
        this.playerUpgradeSO = playerUpgradeSO;

        icon.sprite = playerUpgradeSO.icon;
        title.text = playerUpgradeSO.text;
        upgradeTxt.text = GameLanguageController.UpgradeText;

        switch (playerUpgradeSO.PlayerUpgradeEnum)
        {
            case PlayerUpgrading.PlayerUpgradeEnum.MiningSpeed:
                title.text = GameLanguageController.MiningSpeedText;

                if (playerUpgradeSO.levelPrices.Length + 1 == player.PlayerUpgrading.MiningSpeedMultiplier)
                {
                    levelTitle.text = $"{GameLanguageController.MaxText} {GameLanguageController.LevelText}";
                    priceText.text = $"{GameLanguageController.MaxText}";
                    price = 10000000;

                    upgradeBtn.interactable = false;
                    break;
                }

                levelTitle.text = $"{GameLanguageController.LevelText} {player.PlayerUpgrading.MiningSpeedMultiplier}";
                priceText.text = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.MiningSpeedMultiplier - 1].ToString();
                price = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.MiningSpeedMultiplier - 1];

                break;
            case PlayerUpgrading.PlayerUpgradeEnum.Damage:
                title.text = GameLanguageController.DamageText;

                if (playerUpgradeSO.levelPrices.Length + 1 == player.PlayerUpgrading.ObjectDamageMultiplier)
                {
                    levelTitle.text = $"{GameLanguageController.MaxText} {GameLanguageController.LevelText}";
                    priceText.text = $"{GameLanguageController.MaxText}";
                    price = 10000000;

                    upgradeBtn.interactable = false;
                    break;
                }

                levelTitle.text = $"{GameLanguageController.LevelText} {player.PlayerUpgrading.ObjectDamageMultiplier}";
                priceText.text = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.ObjectDamageMultiplier - 1].ToString();
                price = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.ObjectDamageMultiplier - 1];

                break;
            case PlayerUpgrading.PlayerUpgradeEnum.MineScannerSpeed:
                title.text = GameLanguageController.MineScannerSpeedText;

                if (playerUpgradeSO.levelPrices.Length + 1 == player.PlayerUpgrading.MineScannerSpeedMultiplier)
                {
                    levelTitle.text = $"{GameLanguageController.MaxText} {GameLanguageController.LevelText}";
                    priceText.text = $"{GameLanguageController.MaxText}";
                    price = 10000000;

                    upgradeBtn.interactable = false;
                    break;
                }

                levelTitle.text = $"{GameLanguageController.LevelText} {player.PlayerUpgrading.MineScannerSpeedMultiplier}";
                priceText.text = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.MineScannerSpeedMultiplier - 1].ToString();
                price = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.MineScannerSpeedMultiplier - 1];

                break;
            case PlayerUpgrading.PlayerUpgradeEnum.PlacingSpeed:
                title.text = GameLanguageController.PlacingSpeedText;

                if (playerUpgradeSO.levelPrices.Length + 1 == player.PlayerUpgrading.PlacingSpeedMultiplier)
                {
                    levelTitle.text = $"{GameLanguageController.MaxText} {GameLanguageController.LevelText}";
                    priceText.text = $"{GameLanguageController.MaxText}";
                    price = 10000000;

                    upgradeBtn.interactable = false;
                    break;
                }

                levelTitle.text = $"{GameLanguageController.LevelText}  {player.PlayerUpgrading.PlacingSpeedMultiplier}";
                priceText.text = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.PlacingSpeedMultiplier - 1].ToString();
                price = playerUpgradeSO.levelPrices[(int)player.PlayerUpgrading.PlacingSpeedMultiplier - 1];

                break;
            default:
                break;
        }

    }

}
