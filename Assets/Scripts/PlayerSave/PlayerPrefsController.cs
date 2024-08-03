using System;
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
        MineObjectTraderPriceCountById,
        MineObjectTraderByIdPriceValueByIndex,
        MineObjectTraderByIdUSDParity,
        MineScannerUpgrade,
        MiningSpeedUpgrade,
        ObjectDamageUpgrade,
        PlacingSpeedUpgrade,
        PlayerFirstPlay,
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
        foreach (MineObjectTrader mineObjectTrader in MineObjectTraderContainer.Instance.MineObjectTraderList)
        {
            mineObjectTrader.OnAddingNewPrice += MineObjectTrader_OnAddingNewPrice;
        }
        Player.Instance.OnPlayerFirstPlayChanged += Instance_OnPlayerFirstPlayChanged;

        foreach (MineObject mineObject in Player.Instance.PlayerShopping.MineObjects)
        {
            Player.Instance.PlayerShopping.GetMineObjectFromListByObject(mineObject).Count = GetFloatByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectById, mineObject.MineObjectSO.id, 0);
        }
        Player.Instance.PlayerShopping.Cash = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.PlayerCash,1000);

        Player.Instance.PlayerUpgrading.MineScannerSpeedMultiplier = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.MineScannerUpgrade, 1);
        Player.Instance.PlayerUpgrading.MiningSpeedMultiplier = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.MiningSpeedUpgrade, 1);
        Player.Instance.PlayerUpgrading.ObjectDamageMultiplier = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.ObjectDamageUpgrade, 1);
        Player.Instance.PlayerUpgrading.PlacingSpeedMultiplier = GetFloatByPlayerPrefsEnum(PlayerPrefsEnum.PlacingSpeedUpgrade, 1);
        foreach (MineObjectTrader mineObjectTrader in MineObjectTraderContainer.Instance.MineObjectTraderList)
        {
            mineObjectTrader.PriceHistory = GetFloatListByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectTraderByIdPriceValueByIndex, mineObjectTrader.MineObject.MineObjectSO.id,mineObjectTrader.MineObject.MineObjectSO.startingPrice);
            mineObjectTrader.USDParity = GetFloatByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectTraderByIdUSDParity,mineObjectTrader.MineObject.MineObjectSO.id,mineObjectTrader.MineObject.MineObjectSO.startingPrice);
        }

        Player.Instance.PlayerFirstPlay = GetBoolByPlayerPrefsEnum(PlayerPrefsEnum.PlayerFirstPlay);
    }

    private void Instance_OnPlayerFirstPlayChanged(object sender, EventArgs e)
    {
        SetBoolByPlayerPrefsEnum(PlayerPrefsEnum.PlayerFirstPlay,Player.Instance.PlayerFirstPlay);
    }

    private void MineObjectTrader_OnAddingNewPrice(object sender, System.EventArgs e)
    {
        SetFloatListByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectTraderByIdPriceValueByIndex, ((MineObjectTrader)sender).MineObject.MineObjectSO.id, ((MineObjectTrader)sender).PriceHistory);
        SetFloatByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectTraderByIdUSDParity, ((MineObjectTrader)sender).MineObject.MineObjectSO.id, ((MineObjectTrader)sender).USDParity);
    }

    public void ResetProgress()
    {
        foreach (MineObject mineObject in Player.Instance.PlayerShopping.MineObjects)
        {
            Player.Instance.PlayerShopping.GetMineObjectFromListByObject(mineObject).Count = 0;
        }
        Player.Instance.PlayerShopping.Cash =1000;

        Player.Instance.PlayerUpgrading.MineScannerSpeedMultiplier = 1;
        Player.Instance.PlayerUpgrading.MiningSpeedMultiplier = 1;
        Player.Instance.PlayerUpgrading.ObjectDamageMultiplier = 1;
        Player.Instance.PlayerUpgrading.PlacingSpeedMultiplier = 1;

        foreach (MineObjectTrader mineObjectTrader in MineObjectTraderContainer.Instance.MineObjectTraderList)
        {
            
            mineObjectTrader.PriceHistory.Clear();
            mineObjectTrader.PriceHistory.Add(mineObjectTrader.MineObject.MineObjectSO.startingPrice);
            mineObjectTrader.USDParity = mineObjectTrader.MineObject.MineObjectSO.startingPrice;
            SetFloatListByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectTraderByIdPriceValueByIndex, mineObjectTrader.MineObject.MineObjectSO.id, mineObjectTrader.PriceHistory);
        }
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
    private void SetIntByPlayerPrefsEnumId(PlayerPrefsEnum playerPrefsEnum, int id, int value)
    {
        PlayerPrefs.SetInt(playerPrefsEnum.ToString() + id, value);
    }

    private float GetIntByPlayerPrefsEnumId(PlayerPrefsEnum playerPrefsEnum, int id, int defaultValue)
    {
        return PlayerPrefs.GetInt(playerPrefsEnum.ToString() + id, defaultValue);
    }

    private float GetFloatByPlayerPrefsEnumId(PlayerPrefsEnum playerPrefsEnum, int id,float defaultValue)
    {
        return PlayerPrefs.GetFloat(playerPrefsEnum.ToString()+id,defaultValue);
    }

    private bool GetBoolByPlayerPrefsEnum(PlayerPrefsEnum playerPrefsEnum)
    {
        return Convert.ToBoolean(PlayerPrefs.GetInt(playerPrefsEnum.ToString(), 1));
    }

    private void SetBoolByPlayerPrefsEnum( PlayerPrefsEnum playerPrefsEnum,bool value)
    {
        PlayerPrefs.SetInt(playerPrefsEnum.ToString(), Convert.ToInt32(value));
    }

    private float GetFloatByPlayerPrefsEnum(PlayerPrefsEnum playerPrefsEnum,float defaultValue)
    {
        return PlayerPrefs.GetFloat(playerPrefsEnum.ToString(),defaultValue);
    }

    private void SetFloatListByPlayerPrefsEnumId(PlayerPrefsEnum playerPrefsEnum,int id,List<float> valueList)
    {
        SetIntByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectTraderPriceCountById, id, valueList.Count);

        for (int i = 0; i < valueList.Count; i++)
        {
            PlayerPrefs.SetFloat(playerPrefsEnum.ToString()+id+i, valueList[i]);
        }
    }

    private List<float> GetFloatListByPlayerPrefsEnumId(PlayerPrefsEnum playerPrefsEnum,int id,float defaultValue)
    {
        List<float> value = new List<float>();

        for (int i = 0; i < GetIntByPlayerPrefsEnumId(PlayerPrefsEnum.MineObjectTraderPriceCountById, id,1); i++)
        {
            value.Add(PlayerPrefs.GetFloat(playerPrefsEnum.ToString() + id + i,defaultValue));
        }

        return value;
    }
}
