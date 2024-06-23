using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [field:SerializeField] public ObjectPlacement ObjectPlacement { get; set; }
    [field:SerializeField] public PlayerShopping PlayerShopping { get; set; }
    [field: SerializeField] public PlayerUpgrading PlayerUpgrading { get; set; }


    public IPlayerState PlayerIdleState {  get; set; }
    public IPlayerState PlayerHoldingObjectState {  get; set; }

    private IPlayerStateService _playerStateService;

    private IGridPlacementService _gridPlacementService;
    private IObjectPlacementService _objectPlacementService;
    private IInputService _inputService;
    private IShoppingInGameService _shoppingInGameService;

    [Inject]
    public void Construct(IGridPlacementService gridPlacementService,IObjectPlacementService objectPlacementService, IInputService inputService,IShoppingInGameService shoppingInGameService)
    {
        _gridPlacementService = gridPlacementService;
        _objectPlacementService = objectPlacementService;
        _inputService = inputService;
        _shoppingInGameService= shoppingInGameService;
    }

    private void Awake()
    {
        if (Instance != null) { 
            Destroy(this);
        }
        Instance= this;
        DontDestroyOnLoad(this.gameObject);

        _playerStateService = new PlayerStateManager();

        PlayerIdleState = new PlayerIdleState(this, _playerStateService);
        PlayerHoldingObjectState = new PlayerHoldingObjectState(this,_playerStateService,_gridPlacementService,_objectPlacementService,_inputService,_shoppingInGameService);
    }

    private void Start()
    {
        _playerStateService.Initialize(PlayerIdleState);
    }

    private void Update()
    {
        _playerStateService.CurrentPlayerState.UpdateState();
    }
}
