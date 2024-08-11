using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicIoC : MonoBehaviour
{
    public static BasicIoC Instance { get; set; }

    public IGameReadyService GameReadyService { get; set; }
    public IPlayerDataService PlayerDataService { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

        GameReadyService =new YandexGameReadyManager();
        PlayerDataService=new YGPlayerDataManager();
    }
}
