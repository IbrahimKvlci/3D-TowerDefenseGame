using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameIoC : MonoBehaviour
{
    public static InGameIoC Instance { get; set; }

    public IInputService InputService { get; set; }
    public IEnemyMovementService EnemyMovementService { get; set; }
    public IEnemyDetectPlayerObjectService EnemyDetectPlayerObjectService { get; set; }
    public IEnemyAttackService EnemyAttackService { get; set; }
    public IEnemyHealthService EnemyHealthService { get; set; }
    public IObjectPlacementService ObjectPlacementService { get; set; }
    public IGridPlacementService GridPlacementService { get; set; }
    public IMineWorkingService MineWorkingService { get; set; }
    public IMineTriggerService MineTriggerService { get; set; }
    public IPlayerObjectHealthService PlayerObjectHealthService { get; set; }
    public IPlayerObjectStateService PlayerObjectStateService { get; set; }
    public ITurretTriggerService TurretTriggerService { get; set; }
    public ITurretAttackService TurretAttackService { get; set; }
    public ITurretWorkingService TurretWorkingService { get; set; }
    public IMinePointService MinePointService { get; set; }
    public IMineScannerService MineScannerService { get; set; }
    public IMineScannerMovementService MineScannerMovementService { get; set; }
    public IAttackSpaceShipMovementService AttackSpaceShipMovementService { get; set; }
    public IAttackSpaceShipTriggerService AttackSpaceShipTriggerService { get; set; }
    public IAttackSpaceShipAttackService AttackSpaceShipAttackService { get; set; }
    public IShoppingInGameService ShoppingInGameService { get; set; }
    public IGameControllerService GameControllerService { get; set; }

    private void Awake()
    {
        Instance = this;

        InputService = InputManager.Instance;
        EnemyMovementService = new EnemyMovementManager();
        EnemyDetectPlayerObjectService = new EnemyDetectPlayerObjectManager();
        EnemyHealthService = new EnemyHealthManager();
        EnemyAttackService = new EnemyAttackManager(PlayerObjectHealthService);
        ObjectPlacementService = new ObjectPlacementManager();
        GridPlacementService = new GridPlacementManager(InputService);
        MineWorkingService = new MineWorkingManager();
        MineTriggerService = new MineTriggerManager();
        PlayerObjectHealthService = new PlayerObjectHealthManager();
        PlayerObjectStateService = new PlayerObjectStateManager();
        TurretTriggerService = new TurretTriggerManager();
        TurretAttackService = new TurretAttackManager(EnemyHealthService);
        TurretWorkingService = new TurretWorkingManager();
        MinePointService = new MinePointManager();
        MineScannerService = new MineScannerManager(MinePointService);
        MineScannerMovementService = new MineScannerMovementManager();
        AttackSpaceShipMovementService = new AttackSpaceShipMovementManager();
        AttackSpaceShipTriggerService = new AttackSpaceShipTriggerManger();
        AttackSpaceShipAttackService = new AttackSpaceShipAttackManager(EnemyHealthService);
        ShoppingInGameService = new ShoppingInGameManager(ObjectPlacementService);
        GameControllerService = new GameControllerManager();
    }


}
