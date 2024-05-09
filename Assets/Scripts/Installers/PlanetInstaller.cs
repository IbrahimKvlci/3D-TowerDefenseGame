using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlanetInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IShoppingPlanetService>().To<ShoppingPlanetManager>().AsSingle();
        Container.Bind<IPlanetTravelService>().To<PlanetTravelManager>().AsSingle();

    }
}
