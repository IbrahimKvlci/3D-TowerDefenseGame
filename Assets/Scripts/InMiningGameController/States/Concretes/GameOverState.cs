using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class GameOverState : GameStateBase
{
    private IGameControllerService _gameControllerService;

    public GameOverState(GameController gameController, IGameStateService gameStateService, IGameControllerService gameControllerService) : base(gameController, gameStateService)
    {
        _gameControllerService = gameControllerService;
    }

    public override void EnterState()
    {
        base.EnterState();
        _gameControllerService.FinishTheGame(_gameController, Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject), Player.Instance);

        BasicIoC.Instance.GameReadyService.GameStop();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        Time.timeScale = 0;
    }

    public override void ExitState()
    {
        base.ExitState();
    }
}
