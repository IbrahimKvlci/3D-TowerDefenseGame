using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : GameStateBase
{
    public GamePausedState(GameController gameController, IGameStateService gameStateService) : base(gameController, gameStateService)
    {
    }

    public override void EnterState()
    {
        base.EnterState();

    }

    public override void UpdateState()
    {
        base.UpdateState();
        Time.timeScale = 0;
        if (!_gameController.IsPaused)
        {
            _gameStateService.SwitchState(_gameController.GamePlayingState);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
