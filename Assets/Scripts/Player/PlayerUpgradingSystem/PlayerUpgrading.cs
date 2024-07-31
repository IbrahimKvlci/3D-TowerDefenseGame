using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrading : MonoBehaviour
{
    public event EventHandler OnMiningSpeedUpgrade;
    public event EventHandler OnObjectDamageUpgrade;
    public event EventHandler OnMineScannerUpgrade;
    public event EventHandler OnPlacingSpeedUpgrade;

    public enum PlayerUpgradeEnum
    {
        Damage,
        MineScannerSpeed,
        MiningSpeed,
        PlacingSpeed
    }

    [field: SerializeField] public List<PlayerUpgradeSO> PlayerUpgradeSOList;

    private float _miningSpeedMultiplier;
    public float MiningSpeedMultiplier
    {
        get
        {
            return _miningSpeedMultiplier;
        }
        set
        {
            _miningSpeedMultiplier = value;
            OnMiningSpeedUpgrade?.Invoke(this, EventArgs.Empty);
        }
    }

    private float _objectDamageMultiplier;
    public float ObjectDamageMultiplier
    {
        get
        {
            return _objectDamageMultiplier;
        }
        set
        {
            _objectDamageMultiplier = value;
            OnObjectDamageUpgrade?.Invoke(this, EventArgs.Empty);

        }
    }

    private float _mineScannerSpeedMultiplier;
    public float MineScannerSpeedMultiplier
    {
        get
        {
            return _mineScannerSpeedMultiplier;
        }
        set
        {
            _mineScannerSpeedMultiplier = value;
            OnMineScannerUpgrade?.Invoke(this, EventArgs.Empty);

        }
    }

    private float _placingSpeedMultiplier;
    public float PlacingSpeedMultiplier
    {
        get
        {
            return _placingSpeedMultiplier;
        }
        set
        {
            _placingSpeedMultiplier = value;
            OnPlacingSpeedUpgrade?.Invoke(this, EventArgs.Empty);

        }
    }
}
