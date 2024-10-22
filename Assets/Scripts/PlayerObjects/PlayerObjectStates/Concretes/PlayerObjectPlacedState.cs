using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPlacedState : PlayerObjectStateBase
{
    public PlayerObjectPlacedState(PlayerObject playerObject, IPlayerObjectStateService playerObjectStateService) : base(playerObject, playerObjectStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        _playerObject.IsPlaced = true;
        //_playerObject.PlayerObjectWorkingService.RunTask(_playerObject, _playerObject.Player);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        
    }

    public override void ExitState()
    {
        base.ExitState();
        PlayerObjectPooling.Instance.PlayerObjectPoolingService.RemovePlayerObjectOnList(_playerObject, PlayerObjectPooling.Instance.PlayerObjectList);
    }
}
