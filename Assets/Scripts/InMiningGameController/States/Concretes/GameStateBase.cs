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
