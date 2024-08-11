using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using YG;

public class YGPlayerDataManager : IPlayerDataService
{
    private IImageLoader _imageLoader;

    public Sprite GetPlayerAvatar()
    {
        return UnityWebRequestImageLoader.Instance.GetImageFromURL(YandexGame.playerPhoto);
    }

    public string GetPlayerName()
    {
        return YandexGame.playerName;
    }
}
