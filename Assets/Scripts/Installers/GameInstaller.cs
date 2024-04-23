using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private InputManager inputManager;

    public override void InstallBindings()
    {
        Container.Bind<IInputService>().To<InputManager>().FromComponentInNewPrefab(inputManager).AsSingle();

        Container.Bind<IEnemyMovementService>().To<EnemyMovementManager>().AsSingle();
        Container.Bind<IEnemyDetectPlayerObjectService>().To<EnemyDetectPlayerObjectManager>().AsSingle();
        Container.Bind<IEnemyAttackService>().To<EnemyAttackManager>().AsSingle();
        Container.Bind<IEnemyHealthService>().To<EnemyHealthManager>().AsSingle();

        Container.Bind<IObjectPlacementService>().To<ObjectPlacementManager>().AsSingle();
        Container.Bind<IGridPlacementService>().To<GridPlacementManager>().AsSingle();

        Container.Bind<IMineWorkingService>().To<MineWorkingManager>().AsSingle();

        Container.Bind<IPlayerObjectHealthService>().To<PlayerObjectHealthManager>().AsSingle();
        Container.Bind<IPlayerObjectStateService>().To<PlayerObjectStateManager>().AsSingle();

        Container.Bind<ITurretTriggerService>().To<TurretTriggerManager>().AsSingle();
        Container.Bind<ITurretAttackService>().To<TurretAttackManager>().AsSingle();

    }
}