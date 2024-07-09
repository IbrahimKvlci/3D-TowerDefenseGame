using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayingState : GameStateBase
{
    private IGameControllerService _gameControllerService;
    private IInputService _inputService;
    private IPlanetEnemySpawnerService _planetEnemySpawnerService;

    private float spawningEnemyTimer;
    private float multiplierToSpawnEnemy;

    public GamePlayingState(GameController gameController, IGameStateService gameStateService, IGameControllerService gameControllerService, IInputService inputService, IPlanetEnemySpawnerService planetEnemySpawnerService) : base(gameController, gameStateService)
    {
        _gameControllerService = gameControllerService;
        _inputService = inputService;
        _planetEnemySpawnerService = planetEnemySpawnerService;
    }

    public override void EnterState()
    {
        base.EnterState();
        spawningEnemyTimer = 0;
        multiplierToSpawnEnemy = 1;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        _gameControllerService.CountTheHour(_gameController, _gameController.SpeedOfTheGame);

        if (_gameController.IsPaused)
        {
            _gameStateService.SwitchState(_gameController.GamePausedState);
        }

        if (_gameController.Hour >= _gameController.MaxHour||_gameController.IsGameOver)
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

        if (_gameController.Hour >= Planet.Instace.PlanetSO.startingHourToSpawnEnemy)
        {
            spawningEnemyTimer += Time.deltaTime;
            if (spawningEnemyTimer >= 1 / _gameController.Hour * 1/Planet.Instace.PlanetSO.speedToSpawnEnemy)
            {
                spawningEnemyTimer = 0;

                _planetEnemySpawnerService.SpawnRandomEnemy(Planet.Instace, RandomCirclePosToSpawnEnemy(), multiplierToSpawnEnemy);
                multiplierToSpawnEnemy += 0.2f;
            }
        }
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    private Vector3 RandomCirclePosToSpawnEnemy()
    {
        float randomAngle = Random.Range(0, 360);
        Vector3 randomPoint = new Vector3(Mathf.Cos(randomAngle) * Planet.Instace.PlanetSO.enemySpawningRadius, 0, Mathf.Sin(randomAngle) * Planet.Instace.PlanetSO.enemySpawningRadius) + Planet.Instace.PlanetSO.planetCenter;

        return randomPoint;
    }

}
