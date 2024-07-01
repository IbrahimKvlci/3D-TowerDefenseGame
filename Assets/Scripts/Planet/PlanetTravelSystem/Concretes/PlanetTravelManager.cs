using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTravelManager : IPlanetTravelService
{
    public void TravelToThePlanet(Player player, Planet planet)
    {
        SceneLoader.LoadScene(planet.PlanetSO.scene);
    }
}
