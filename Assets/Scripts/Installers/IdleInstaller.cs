using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class IdleInstaller : MonoInstaller
{
    [SerializeField] private UpgradeSingleUI upgradeSingleUIPrefab;

    public override void InstallBindings()
    {
        Container.BindFactory<UpgradeSingleUI, UpgradeSingleUI.Factory>().FromComponentInNewPrefab(upgradeSingleUIPrefab);

        Container.Bind<IPlayerShoppingService>().To<PlayerShoppingManager>().AsSingle();
        Container.Bind<IShoppingUpgradeService>().To<ShoppingUpgradeManager>().AsSingle();
        Container.Bind<IPlayerUpgradingService>().To<PlayerUpgradingManager>().AsSingle();


    }
}
