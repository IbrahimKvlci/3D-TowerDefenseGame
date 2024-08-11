using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class YandexGameReadyManager : IGameReadyService
{
    public void GameReady()
    {
        YandexGame.GameReadyAPI();
    }

    public void GameStart()
    {
        YandexGame.GameplayStart();
    }

    public void GameStop()
    {
        YandexGame.GameplayStop();
    }
}
