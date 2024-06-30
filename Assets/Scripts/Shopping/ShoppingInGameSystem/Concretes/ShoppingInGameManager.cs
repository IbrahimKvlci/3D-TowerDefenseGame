using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingInGameManager : IShoppingInGameService
{
    private IObjectPlacementService _objectPlacementService;
    public ShoppingInGameManager(IObjectPlacementService objectPlacementService)
    {
        _objectPlacementService = objectPlacementService;
    }

    public void BuyPlayerObjectProduct(Player player, PlayerObjectProduct product)
    {
        if (player.PlayerShopping.Cash >= ((PlayerObjectProductSO)product.PlayerObjectSO).Price)
        {
            player.PlayerShopping.Cash -= ((PlayerObjectProductSO)product.PlayerObjectSO).Price;
            player.PlayerShopping.Cost += ((PlayerObjectProductSO)product.PlayerObjectSO).Price;
            _objectPlacementService.PlaceObject( player,player.ObjectPlacement.PlayerObjectToPlace);
        }
        else
        {
            Debug.LogError("Cash is not enough");
        }
    }

    public void CancelBuying(Player player)
    {
        _objectPlacementService.ClearObjectToPlaceBase(player);
    }

    public void GivePlayerObjectProductToPlayer(Player player, PlayerObjectProduct product)
    {
        _objectPlacementService.SetObjectToPlace(player, product);
    }
    
}
