using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineStateBase : IMineState
{
    protected private Mine _mine;
    protected private IMineStateService _mineStateService;

    public MineStateBase(Mine mine, IMineStateService mineStateService)
    {
        _mine = mine;
        _mineStateService= mineStateService;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
    }
}
