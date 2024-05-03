using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerStateBase
{
    public PlayerIdleState(Player player, IPlayerStateService playerStateService) : base(player, playerStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();

        if(_player.ObjectPlacement.PlayerObjectToPlace!=null)
        {
            _playerStateService.SwitchState(_player.PlayerHoldingObjectState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
