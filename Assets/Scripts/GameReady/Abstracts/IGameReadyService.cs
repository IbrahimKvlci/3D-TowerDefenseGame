using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameReadyService
{
    void GameReady();
    void GameStart();
    void GameStop();
}
