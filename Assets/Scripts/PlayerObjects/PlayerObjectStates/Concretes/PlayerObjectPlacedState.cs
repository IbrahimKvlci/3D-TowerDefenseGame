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
        PlayerObjectPooling.Instance.PlayerObjectPoolingService.AddPlayerObjectToList(_playerObject, PlayerObjectPooling.Instance.PlayerObjectList);
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _playerObject.PlayerObjectWorkingService.RunTask(_playerObject);
    }

    public override void ExitState()
    {
        base.ExitState();
        PlayerObjectPooling.Instance.PlayerObjectPoolingService.RemovePlayerObjectOnList(_playerObject, PlayerObjectPooling.Instance.PlayerObjectList);
    }
}
