using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PlayerUpgradeSO : ScriptableObject
{
    public PlayerUpgrading.PlayerUpgradeEnum PlayerUpgradeEnum;
    public Sprite icon;
    public string text;
    public int[] levelPrices;
}
