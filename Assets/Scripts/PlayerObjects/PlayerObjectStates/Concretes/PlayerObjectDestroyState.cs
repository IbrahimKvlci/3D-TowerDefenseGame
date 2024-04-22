using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectDestroyState : PlayerObjectStateBase
{
    protected private IPlayerObjectHealthService _playerObjectHealthService; 

    public PlayerObjectDestroyState(PlayerObject playerObject, IPlayerObjectStateService playerObjectStateService, IPlayerObjectHealthService playerObjectHealthService) : base(playerObject, playerObjectStateService)
    {
        _playerObjectHealthService = playerObjectHealthService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _playerObjectHealthService.DestroySelf(_playerObject);
    }

    public override void UpdateState()
    {
        base.UpdateState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
