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
        cashText.text = $"${Player.Instance.PlayerShopping.Cash}";
    }

    private void PlayerInfoUI_OnMineObjectCurrentCollectedCountChanged(object sender, System.EventArgs e)
    {
        mineObjectText.text = Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).CurrentCollectedCount.ToString();
    }

    private void UpdateVisual()
    {
        Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).OnMineObjectCurrentCollectedCountChanged += PlayerInfoUI_OnMineObjectCurrentCollectedCountChanged;

        cashText.text = $"${Player.Instance.PlayerShopping.Cash}";
        mineObjectText.text = Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).CurrentCollectedCount.ToString();
        mineObjectImage.sprite = Planet.Instace.PlanetSO.mineObject.MineObjectSO.icon;
    }
}
