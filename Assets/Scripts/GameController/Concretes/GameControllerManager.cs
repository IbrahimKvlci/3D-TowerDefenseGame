using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerManager : IGameControllerService
{
    public void CountTheDay(GameController gameController, float daySpeed)
    {
        gameController.Day += Time.deltaTime * daySpeed;
    }

    public void FinishTheGame()
    {
        //Finish
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
