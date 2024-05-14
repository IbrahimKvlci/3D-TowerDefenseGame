using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoppingManager : IPlayerShoppingService
{
    public bool CheckPlayerCash(Player player, int price)
    {
        return player.PlayerShopping.Cash >= price;
    }

    public void Purchase(Player player, int price)
    {
        player.PlayerShopping.Cash -= price;
    }
}
