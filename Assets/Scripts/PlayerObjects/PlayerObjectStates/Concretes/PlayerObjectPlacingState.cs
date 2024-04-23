using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPlacingState : PlayerObjectStateBase
{
    private float timer;

    public PlayerObjectPlacingState(PlayerObject playerObject, IPlayerObjectStateService playerObjectStateService) : base(playerObject, playerObjectStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        timer = 0;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        timer+= Time.deltaTime;
        if (timer > _playerObject.PlayerObjectSO.placingTime)
        {
            timer = 0;
            _playerObjectStateService.SwitchState(_playerObject.PlayerObjectPlacedState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}