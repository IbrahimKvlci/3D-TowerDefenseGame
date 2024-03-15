using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectDestroyState : PlayerObjectStateBase
{
    public PlayerObjectDestroyState(PlayerObject playerObject, IPlayerObjectStateService playerObjectStateService) : base(playerObject, playerObjectStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
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
