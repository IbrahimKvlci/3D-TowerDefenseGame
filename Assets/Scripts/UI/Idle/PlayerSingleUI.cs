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

    public void SetPlayerUI(Player player)
    {
        playerAvatar.sprite=player.PlayerInfo.Avatar;
        nameText.text=player.PlayerInfo.Name;
        cashText.text = $"${player.PlayerShopping.Cash}";
    }
}
