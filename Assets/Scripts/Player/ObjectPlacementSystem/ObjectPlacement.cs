using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPlacement:MonoBehaviour
{
    [field:SerializeField] public LayerMask PlaneLayer {  get;  set; }
    [SerializeField] private PlayerObject playerObject;
    [field:SerializeField] public GridPlacement GridPlacement {  get; set; }
    [SerializeField] private Player player;

    private PlayerObject _playerObjectToPlace;
    public PlayerObject PlayerObjectToPlace
    {
        get { return _playerObjectToPlace; }
        set { _playerObjectToPlace = value; }
    }

    private IObjectPlacementService _objectPlacementService;
    private IGridPlacementService _gridPlacementService;
    private IInputService _inputService;
    private IShoppingInGameService _shoppingInGameService;

    [Inject]
    public void Construct(IObjectPlacementService objectPlacementService,IGridPlacementService gridPlacementService,IInputService inputService, IShoppingInGameService shoppingInGameService)
    {
        _objectPlacementService = objectPlacementService;
        _gridPlacementService = gridPlacementService;
        _inputService = inputService;
        _shoppingInGameService = shoppingInGameService;

    }

    private void Awake()
    {
        GridPlacement = GridPlacement.Instance;
        PlayerObjectToPlace = playerObject;
        player = Player.Instance;

        player.PlayerHoldingObjectState = new PlayerHoldingObjectState(player, player.PlayerStateService, _gridPlacementService, _objectPlacementService, _inputService, _shoppingInGameService);

        player.ObjectPlacement = this;
    }

    public class Factory : PlaceholderFactory<ObjectPlacement> { }




}
