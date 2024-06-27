using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private void Awake()
    {
        _objectPlacementService = InGameIoC.Instance.ObjectPlacementService;
        _gridPlacementService= InGameIoC.Instance.GridPlacementService;
        _inputService= InGameIoC.Instance.InputService;
        _shoppingInGameService= InGameIoC.Instance.ShoppingInGameService;

        GridPlacement = GridPlacement.Instance;
        PlayerObjectToPlace = playerObject;
        player = Player.Instance;

        player.PlayerHoldingObjectState = new PlayerHoldingObjectState(player, player.PlayerStateService, _gridPlacementService, _objectPlacementService, _inputService, _shoppingInGameService);

        player.ObjectPlacement = this;
    }





}
