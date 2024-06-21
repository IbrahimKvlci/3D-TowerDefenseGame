using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateBase : IGameState
{
    protected GameController _gameController;
    protected IGameStateService _gameStateService;

    public GameStateBase(GameController gameController, IGameStateService gameStateService)
    {
        _gameController = gameController;
        _gameStateService = gameStateService;
    }

    public void EnterState()
    {
    }
    public void ExitState()
    {
    }

    public void UpdateState()
    {
    }
}
