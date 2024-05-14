using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerShoppingService
{
    void Purchase(Player player, int price);

    bool CheckPlayerCash(Player player,int price);
}
