using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cashText, mineObjectText;
    [SerializeField] private Image mineObjectImage;

    private void Start()
    {
        Player.Instance.PlayerShopping.OnCashChanged += PlayerShopping_OnCashChanged;

        UpdateVisual();
    }

    private void PlayerShopping_OnCashChanged(object sender, System.EventArgs e)
    {
        cashText.text = $"${Math.Truncate(Player.Instance.PlayerShopping.Cash * 100) / 100}";
    }

    private void PlayerInfoUI_OnMineObjectCurrentCollectedCountChanged(object sender, System.EventArgs e)
    {
        mineObjectText.text = (Math.Truncate(Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).CurrentCollectedCount * 100) / 100).ToString();
    }

    private void UpdateVisual()
    {
        Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).OnMineObjectCurrentCollectedCountChanged += PlayerInfoUI_OnMineObjectCurrentCollectedCountChanged;

        cashText.text = $"${Math.Truncate(Player.Instance.PlayerShopping.Cash * 100) / 100}";
        mineObjectText.text = (Math.Truncate(Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).CurrentCollectedCount*100)/100).ToString();
        mineObjectImage.sprite = Planet.Instace.PlanetSO.mineObject.MineObjectSO.icon;
    }
}
