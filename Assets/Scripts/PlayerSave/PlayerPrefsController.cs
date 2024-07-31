using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    public static PlayerPrefsController Instance { get; set; }

    enum PlayerPrefsEnum
    {
        PlayerCash,
        MineObjectById,
        MineScannerUpgrade,
        MiningSpeedUpgrade,
        ObjectDamageUpgrade,
        PlacingSpeedUpgrade,
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        Player.Instance.PlayerShopping.OnCashChanged += PlayerShopping_OnCashChanged;
        foreach (MineObject mineObject in Player.Instance.PlayerShopping.MineObjects)
        {
            mineObject.OnMineObjectCountChanged += MineObject_OnMineObjectCountChanged;
        }
        Player.Instance.PlayerUpgrading.OnMineScannerUpgrade += PlayerUpgrading_OnMineScannerUpgrade;
        Player.Instance.PlayerUpgrading.OnMiningSpeedUpgrade += PlayerUpgrading_OnMiningSpeedUpgrade;
        Player.Instance.PlayerUpgrading.OnObjectDamageUpgrade += PlayerUpgrading_OnObjectDamageUpgrade;
        Player.Instance.PlayerUpgrading.OnPlacingSpeedUpgrade += PlayerUpgrading_OnPlacingSpeedUpgrade;

        foreach (MineObject mineObject in Player.Instance.PlayerShopping.MineObjects)
        {
            Player.Instance.PlayerShopping.GetMineObjectFromListByObject(mineObject).Count = GetFloatByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectById, mineObject.MineObjectSO.id, 0);
        }
        Player.Instance.PlayerShopping.Cash = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.PlayerCash,1000);

        Player.Instance.PlayerUpgrading.MineScannerSpeedMultiplier = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.MineScannerUpgrade, 1);
        Player.Instance.PlayerUpgrading.MiningSpeedMultiplier = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.MiningSpeedUpgrade, 1);
        Player.Instance.PlayerUpgrading.ObjectDamageMultiplier = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.ObjectDamageUpgrade, 1);
        Player.Instance.PlayerUpgrading.PlacingSpeedMultiplier = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.PlacingSpeedUpgrade, 1);

    }

    private void PlayerUpgrading_OnPlacingSpeedUpgrade(object sender, System.EventArgs e)
    {
        SetFloatByPlayerPrefsEnum(PlayerPrefsEnum.PlacingSpeedUpgrade,Player.Instance.PlayerUpgrading.MiningSpeedMultiplier);
    }

    private void PlayerUpgrading_OnObjectDamageUpgrade(object sender, System.EventArgs e)
    {
        SetFloatByPlayerPrefsEnum(PlayerPrefsEnum.ObjectDamageUpgrade, Player.Instance.PlayerUpgrading.ObjectDamageMultiplier);

    }

    private void PlayerUpgrading_OnMiningSpeedUpgrade(object sender, System.EventArgs e)
    {
        SetFloatByPlayerPrefsEnum(PlayerPrefsEnum.MiningSpeedUpgrade, Player.Instance.PlayerUpgrading.MiningSpeedMultiplier);

    }

    private void PlayerUpgrading_OnMineScannerUpgrade(object sender, System.EventArgs e)
    {
        SetFloatByPlayerPrefsEnum(PlayerPrefsEnum.MineScannerUpgrade, Player.Instance.PlayerUpgrading.MineScannerSpeedMultiplier);

    }

    private void MineObject_OnMineObjectCountChanged(object sender, System.EventArgs e)
    {
        SetFloatByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectById, ((MineObject)sender).MineObjectSO.id, ((MineObject)sender).Count);
    }

    private void PlayerShopping_OnCashChanged(object sender, System.EventArgs e)
    {
        SetFloatByPlayerPrefsEnum(PlayerPrefsEnum.PlayerCash,Player.Instance.PlayerShopping.Cash);
    }
    private void SetFloatByPlayerPrefsEnum(PlayerPrefsEnum playerPrefsEnum,float value)
    {
        PlayerPrefs.SetFloat(playerPrefsEnum.ToString(), value);
    }

    private void SetFloatByPlayerPrefsEnumId(PlayerPrefsEnum playerPrefsEnum,int id,float value)
    {
        PlayerPrefs.SetFloat(playerPrefsEnum.ToString()+id, value);
    }

    private float GetFloatByPlayerPrefsEnumId(PlayerPrefsEnum playerPrefsEnum, int id,float defaultValue)
    {
        return PlayerPrefs.GetFloat(playerPrefsEnum.ToString()+id,defaultValue);
    }

    private float GetFloatByPlayerPrefsEnum(PlayerPrefsEnum playerPrefsEnum,float defaultValue)
    {
        return PlayerPrefs.GetFloat(playerPrefsEnum.ToString(),defaultValue);
    }
}
