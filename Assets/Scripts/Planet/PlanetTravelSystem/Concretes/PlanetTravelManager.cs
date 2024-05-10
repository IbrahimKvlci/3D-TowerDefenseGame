using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetTravelManager : IPlanetTravelService
{
    public void TravelToThePlanet(Player player, Planet planet)
    {
        Debug.Log($"Travel {planet.PlanetSO.title}");
        SceneLoader.LoadScene(planet.PlanetSO.scene);
    }
}
