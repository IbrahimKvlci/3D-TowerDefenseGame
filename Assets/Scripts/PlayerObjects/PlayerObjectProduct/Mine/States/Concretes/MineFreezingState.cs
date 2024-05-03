using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineFreezingState : MineStateBase
{
    public MineFreezingState(Mine mine, IMineStateService mineStateService) : base(mine, mineStateService)
    {
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (_mine.IsPlaced)
        {
            _mine.MineStateService.SwitchState(_mine.MineIdleState);
        }
    }
}
