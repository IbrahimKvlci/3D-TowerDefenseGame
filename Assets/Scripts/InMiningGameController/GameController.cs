using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [field: SerializeField] public float MaxHour { get; set; }
    [field:SerializeField] public float SpeedOfTheGame { get; set; }
    public float Hour { get; set; }
    public bool IsPaused { get; set; }
    public bool IsGameOver { get; set; }

    private IGameControllerService _gameControllerService;
    private IInputService _inputService;
    private IPlanetEnemySpawnerService _planerEnemySpawnerService;

    public IGameState GamePlayingState { get; set; }
    public IGameState GamePausedState { get; set; }
    public IGameState GameOverState { get; set; }

    private IGameStateService _gameStateService;

    public static GameController Instance { get; set; }

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance);
        }
        Instance = this;

        _inputService=InGameIoC.Instance.InputService;
        _gameControllerService = InGameIoC.Instance.GameControllerService;
        _planerEnemySpawnerService = InGameIoC.Instance.PlanetEnemySpawnerService;

        _gameStateService = new GameStateManager();

        GamePlayingState = new GamePlayingState(this,_gameStateService,_gameControllerService,_inputService,_planerEnemySpawnerService);
        GamePausedState = new GamePausedState(this, _gameStateService);
        GameOverState=new GameOverState(this, _gameStateService,_gameControllerService);
    }

    private void Start()
    {
        Hour = 0;
        IsGameOver = false;
        IsPaused = false;
        _gameStateService.Initialize(GamePlayingState);
    }

    private void Update()
    {
        _gameStateService.CurrentGameState.UpdateState();
    }

}
