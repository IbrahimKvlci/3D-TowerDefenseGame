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

    public void SetUpgrade(PlayerUpgradeSO playerUpgradeSO,Player player)
    {
        icon.sprite = playerUpgradeSO.icon;
        title.text = playerUpgradeSO.text;
        switch (playerUpgradeSO.id)
        {
            case 1:
                levelTitle.text = $"Level {player.PlayerUpgrading.MiningSpeedMultiplier}";
                break;
            case 2:
                levelTitle.text = $"Level {player.PlayerUpgrading.MiningSpeedMultiplier}";
                break;
            case 3:
                levelTitle.text = $"Level {player.PlayerUpgrading.MiningSpeedMultiplier}";
                break;
            case 4:
                levelTitle.text = $"Level {player.PlayerUpgrading.MiningSpeedMultiplier}";
                break;
            default:
                break;
        }
    }
}
