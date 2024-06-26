using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSingleUI : MonoBehaviour
{
    [SerializeField] private Image playerAvatar;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI cashText;
    private Player player;

    public void SetPlayerUI(Player player)
    {
        player.PlayerShopping.OnCashChanged += PlayerShopping_OnCashChanged;
        this.player = player;

        playerAvatar.sprite=player.PlayerInfo.Avatar;
        nameText.text=player.PlayerInfo.Name;
        cashText.text = $"${player.PlayerShopping.Cash}" ;
    }

    private void PlayerShopping_OnCashChanged(object sender, System.EventArgs e)
    {
        cashText.text = $"${player.PlayerShopping.Cash}";
    }
}
