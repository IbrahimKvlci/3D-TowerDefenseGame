using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [field:SerializeField]public float SpeedOfTheGame { get; set; }
    public float Day { get; set; }
    public bool IsPaused { get; set; }
    public bool IsGameOver { get; set; }

    private IGameControllerService _gameControllerService;

    [Inject]
    public void Construct(IGameControllerService gameControllerService)
    {
        _gameControllerService = gameControllerService;
    }

    private void Start()
    {
        Day = 0;
    }

    private void Update()
    {
    }
}
