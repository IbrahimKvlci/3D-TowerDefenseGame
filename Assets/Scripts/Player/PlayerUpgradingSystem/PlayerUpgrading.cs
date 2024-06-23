using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrading : MonoBehaviour
{
    public enum PlayerUpgradeEnum
    {
        Damage,
        MineScannerSpeed,
        MiningSpeed,
        PlacingSpeed
    }

    [field: SerializeField] public List<PlayerUpgradeSO> PlayerUpgradeSOList;
    public float MiningSpeedMultiplier { get; set; } = 1f;
    public float ObjectDamageMultiplier { get; set; }=1f;
    public float MineScannerSpeedMultiplier { get; set; } = 1f;
    public float PlacingSpeedMultiplier { get; set; }=1f;
}
