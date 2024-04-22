using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectStateBase : IPlayerObjectState 
{
    protected PlayerObject _playerObject;
    protected IPlayerObjectStateService _playerObjectStateService;

    public PlayerObjectStateBase(PlayerObject playerObject, IPlayerObjectStateService playerObjectStateService)
    {
        _playerObject = playerObject;
        _playerObjectStateService = playerObjectStateService;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
        if(this is not PlayerObjectDestroyState)
        {
            if (_playerObject.PlayerObjectHealth.IsDead)
            {
                _playerObjectStateService.SwitchState(_playerObject.PlayerObjectDestroyState);
            }
        }
    }
}
