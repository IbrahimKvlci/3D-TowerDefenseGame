using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [field:SerializeField]public float SpeedOfTheGame { get; set; }
    public float Day { get; set; }
    public bool IsPaused { get; set; }
    public bool IsGameOver { get; set; }

    private IGameControllerService _gameControllerService;

    private void Awake()
    {
        _gameControllerService = InGameIoC.Instance.GameControllerService;
    }

    private void Start()
    {
        Day = 0;
    }

    private void Update()
    {
    }
}
