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

    public void FinishTheGame(GameController gameController,MineObject mineObject, Player player)
    {
        OnGameOver?.Invoke(this, EventArgs.Empty);

        gameController.IsGameOver = true;
        _mineObjectService.GiveCollectedMineObjectToPlayer(mineObject, player);
    }

    public void PauseTheGame(GameController gameController)
    {
        if(gameController.IsPaused)
        {
            Time.timeScale = 1.0f;
        }
        else
        {
            Time.timeScale = 0.0f;
        }
    }

    public void SpeedUpTheGame(float speed)
    {
        Time.timeScale= speed;
    }
}
