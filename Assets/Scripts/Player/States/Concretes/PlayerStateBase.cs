using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateBase : IPlayerState
{
    protected Player _player;
    protected IPlayerStateService _playerStateService;

    public PlayerStateBase(Player player, IPlayerStateService playerStateService)
    {
        _player = player;
        _playerStateService = playerStateService;
    }

    public virtual void EnterState()
    {
    }

    public virtual void ExitState()
    {
    }

    public virtual void UpdateState()
    {
        if (_playerStateService.CurrentPlayerState != _player.PlayerBankruptcyState&&_player.PlayerWentBankrupt)
        {
            _playerStateService.SwitchState(_player.PlayerBankruptcyState);
        }
    }
}
