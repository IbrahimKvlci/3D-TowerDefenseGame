using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameControllerService
{
    event EventHandler OnGameOver;

    void SpeedUpTheGame(float speed);
    void FinishTheGame(GameController gameController,MineObject mineObject, Player player);
    void PauseTheGame(GameController gameController);
    void ResumeTheGame(GameController gameController);
    void CountTheHour(GameController gameController,float hourSpeed);
}
