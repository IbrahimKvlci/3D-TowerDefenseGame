using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameStateBase
{
    private IGameControllerService _gameControllerService;
    private IInputService _inputService;

    public GamePlayingState(GameController gameController, IGameStateService gameStateService, IGameControllerService gameControllerService, IInputService inputService) : base(gameController, gameStateService)
    {
        _gameControllerService = gameControllerService;
        _inputService = inputService;
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _gameControllerService.CountTheHour(_gameController, _gameController.SpeedOfTheGame);

        if (_gameController.Hour >= _gameController.MaxHour)
        {
            _gameStateService.SwitchState(_gameController.GameOverState);
        }
        if (_inputService.IsSpeedUpKeyDown())
        {
            _gameControllerService.SpeedUpTheGame(5);
        }
        else
        {
            _gameControllerService.SpeedUpTheGame(1);
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

}
