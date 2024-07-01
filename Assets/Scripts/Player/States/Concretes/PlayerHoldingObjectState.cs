using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHoldingObjectState : PlayerStateBase
{
    private IGridPlacementService _gridPlacementService;
    private IObjectPlacementService _objectPlacementService;
    private IInputService _inputService;
    private IShoppingInGameService _shoppingInGameService;

    public PlayerHoldingObjectState(Player player, IPlayerStateService playerStateService,IGridPlacementService gridPlacementService,IObjectPlacementService objectPlacementService,IInputService inputService,IShoppingInGameService shoppingInGameService) : base(player, playerStateService)
    {
        _gridPlacementService = gridPlacementService;
        _objectPlacementService = objectPlacementService;
        _inputService = inputService;
        _shoppingInGameService = shoppingInGameService;
    }

    public override void EnterState()
    {
        base.EnterState();

    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_player.ObjectPlacement.PlayerObjectToPlace == null)
        {
            _playerStateService.SwitchState(_player.PlayerIdleState);
        }
        else
        {
            if (_inputService.IsMouseOnAPlane(_player.ObjectPlacement.PlaneLayer))
            {
                Vector3 playerObjectPos = _gridPlacementService.GetGridCellPositionByMousePosition(_player.ObjectPlacement.GridPlacement, _player.ObjectPlacement.PlaneLayer);
                _objectPlacementService.HandlePlacingObjectPlacement(_player.ObjectPlacement.PlayerObjectToPlace, playerObjectPos);

                if (_inputService.MouseLeftKeyDown())
                {
                    //_objectPalcementService.PlaceObject(ref _playerObjectToPlace);
                    _shoppingInGameService.BuyPlayerObjectProduct(_player, (PlayerObjectProduct)_player.ObjectPlacement.PlayerObjectToPlace);
                }
            }
            else
            {
                _objectPlacementService.HandlePlacingObjectPlacement(_player.ObjectPlacement.PlayerObjectToPlace, _inputService.GetMousePositionOnWorldPoint());
            }


        }

    }

    public override void ExitState()
    {
        base.ExitState();
    }


}
