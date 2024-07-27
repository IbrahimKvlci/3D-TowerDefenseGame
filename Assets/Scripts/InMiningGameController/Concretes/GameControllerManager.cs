using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerManager : IGameControllerService
{
    private IMineObjectService _mineObjectService;

    public GameControllerManager(IMineObjectService mineObjectService)
    {
        _mineObjectService = mineObjectService;
    }

    public event EventHandler OnGameOver;

    public void CountTheHour(GameController gameController, float hourSpeed)
    {
        gameController.Hour += Time.deltaTime * hourSpeed;
    }

    public void FinishTheGame(GameController gameController, MineObject mineObject, Player player)
    {
        OnGameOver?.Invoke(this, EventArgs.Empty);

        gameController.IsGameOver = true;
        _mineObjectService.GiveCollectedMineObjectToPlayer(mineObject, player);
        GameManager.Instance.EndOfTheDay();
    }

    public void PauseTheGame(GameController gameController)
    {
        gameController.IsPaused = true;
    }

    public void ResumeTheGame(GameController gameController)
    {
        gameController.IsPaused = false;
    }

    public void SpeedUpTheGame(float speed)
    {
        Time.timeScale = speed;
    }
}
