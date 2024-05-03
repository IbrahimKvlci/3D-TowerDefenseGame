using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShoppingInGameService
{
    void BuyPlayerObjectProduct(Player player,PlayerObjectProduct product);
    void GivePlayerObjectProductToPlayer(Player player,PlayerObjectProduct product);
    void CancelBuying(Player player);
}
