using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameControllerService
{
    void SpeedUpTheGame(float speed);
    void FinishTheGame();
    void PauseTheGame(GameController gameController);
    void CountTheDay(GameController gameController,float daySpeed);
}
