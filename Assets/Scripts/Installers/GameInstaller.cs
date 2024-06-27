using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private PlayerObjectSingleUI playerObjectSingleUIPrefab;
    [SerializeField] private ObjectPlacement objectPlacementPrefab;


    public override void InstallBindings()
    {
        Container.BindFactory<PlayerObjectSingleUI, PlayerObjectSingleUI.Factory>().FromComponentInNewPrefab(playerObjectSingleUIPrefab);
        Container.BindFactory<ObjectPlacement, ObjectPlacement.Factory>().FromComponentInNewPrefab(objectPlacementPrefab);


        Container.Bind<IInputService>().To<InputManager>().FromComponentInNewPrefab(inputManager).AsSingle();

        Container.Bind<IEnemyMovementService>().To<EnemyMovementManager>().AsSingle();
        Container.Bind<IEnemyDetectPlayerObjectService>().To<EnemyDetectPlayerObjectManager>().AsSingle();
        Container.Bind<IEnemyAttackService>().To<EnemyAttackManager>().AsSingle();
        Container.Bind<IEnemyHealthService>().To<EnemyHealthManager>().AsSingle();

        Container.Bind<IObjectPlacementService>().To<ObjectPlacementManager>().AsSingle();
        Container.Bind<IGridPlacementService>().To<GridPlacementManager>().AsSingle();

        Container.Bind<IMineWorkingService>().To<MineWorkingManager>().AsSingle();
        Container.Bind<IMineTriggerService>().To<MineTriggerManager>().AsSingle();

        Container.Bind<IPlayerObjectHealthService>().To<PlayerObjectHealthManager>().AsSingle();
        Container.Bind<IPlayerObjectStateService>().To<PlayerObjectStateManager>().AsSingle();

        Container.Bind<ITurretTriggerService>().To<TurretTriggerManager>().AsSingle();
        Container.Bind<ITurretAttackService>().To<TurretAttackManager>().AsSingle();
        Container.Bind<ITurretWorkingService>().To<TurretWorkingManager>().AsSingle();

        Container.Bind<IMinePointService>().To<MinePointManager>().AsSingle();

        Container.Bind<IMineScannerService>().To<MineScannerManager>().AsSingle();
        Container.Bind<IMineScannerMovementService>().To<MineScannerMovementManager>().AsSingle();

        Container.Bind<IAttackSpaceShipMovementService>().To<AttackSpaceShipMovementManager>().AsSingle();
        Container.Bind<IAttackSpaceShipTriggerService>().To<AttackSpaceShipTriggerManger>().AsSingle();
        Container.Bind<IAttackSpaceShipAttackService>().To<AttackSpaceShipAttackManager>().AsSingle();


        Container.Bind<IShoppingInGameService>().To<ShoppingInGameManager>().AsSingle();

        Container.Bind<IGameControllerService>().To<GameControllerManager>().AsSingle();

    }
}