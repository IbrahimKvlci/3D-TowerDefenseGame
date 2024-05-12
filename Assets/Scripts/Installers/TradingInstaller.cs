using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TradingInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ITradingMineObjectService>().To<TradingMineObjectManager>().AsSingle();
        

    }
}
