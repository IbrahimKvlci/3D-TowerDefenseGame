using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingPlanetManager : IShoppingPlanetService
{

    private IPlanetTravelService _planetTravelService;
    public ShoppingPlanetManager(IPlanetTravelService planetTravelService)
    {
        _planetTravelService= planetTravelService;
        Debug.Log(_planetTravelService);
    }

    public void PayToTravelThePlanet(Player player, Planet planet)
    {
        if (player.PlayerShopping.Cash >= planet.PlanetSO.price)
        {
            player.PlayerShopping.Cash-=planet.PlanetSO.price;

           _planetTravelService.TravelToThePlanet(player, planet);
        }
        else
        {
            Debug.LogError("Cash is not enough!");
        }
    }
}
