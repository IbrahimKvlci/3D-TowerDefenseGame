using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHoldingObjectState : PlayerStateBase
{
    public event EventHandler OnObjectPlace;

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
                    bool canPlace=true;
                    for (int i = 0; i < PlayerObjectPooling.Instance.PlayerObjectList.Count; i++)
                    {
                        if (_player.ObjectPlacement.PlayerObjectToPlace.transform.position == PlayerObjectPooling.Instance.PlayerObjectList[i].transform.position)
                            canPlace=false;
                    }

                    if (canPlace)
                    {
                        Vector3 objecPos = _player.ObjectPlacement.PlayerObjectToPlace.transform.position;

                        bool isObjectPurchased;
                        _shoppingInGameService.BuyPlayerObjectProduct(_player, (PlayerObjectProduct)_player.ObjectPlacement.PlayerObjectToPlace,out isObjectPurchased);

                        if(isObjectPurchased)
                        {
                            //OnObjectPlace?.Invoke(this, EventArgs.Empty);
                            InGameSoundManager.Instance.PlayAudioOnCamera(InGameSoundManager.Instance.InGameSoundEffectsSO.purchaseFx, 1);

                            OnObjectPlace?.Invoke(this, EventArgs.Empty);
                        }
                        else
                        {
                            //OnCashNotEnough?.Invoke(this, EventArgs.Empty);
                            InGameSoundManager.Instance.PlayAudioOnCamera(InGameSoundManager.Instance.InGameSoundEffectsSO.wrongPutFx, 1);
                            Debug.Log(objecPos);

                        }
                    }
                    else
                    {
                        Debug.Log("You cannot place");
                        InGameSoundManager.Instance.PlayAudioOnCamera(InGameSoundManager.Instance.InGameSoundEffectsSO.wrongPutFx, 1);

                        //OnObjectCannotPlace?.Invoke(this, EventArgs.Empty);
                    }
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
