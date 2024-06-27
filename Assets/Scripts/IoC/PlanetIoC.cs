using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetIoC : MonoBehaviour
{
    public IShoppingPlanetService ShoppingPlanetService { get; set; }
    public IPlanetTravelService PlanetTravelService { get; set; }

    public static PlanetIoC Instance { get; set; }

    private void Awake()
    {
        Instance = this;

        PlanetTravelService = new PlanetTravelManager();
        ShoppingPlanetService = new ShoppingPlanetManager(PlanetTravelService);
    }
}
