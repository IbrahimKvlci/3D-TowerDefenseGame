using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePausedState : GameStateBase
{
    public GamePausedState(GameController gameController, IGameStateService gameStateService) : base(gameController, gameStateService)
    {
    }
}
