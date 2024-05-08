using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSafeState : GameStateBase
{
    public GameSafeState(GameController gameController, IGameStateService gameStateService) : base(gameController, gameStateService)
    {
    }
}
