using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class PlayerObject : MonoBehaviour
{

    public PlayerObjectHealth PlayerObjectHealth { get; set; }

    public IPlayerObjectHealthService PlayerObjectHealthService { get; private set; }


    private void Awake()
    {
        PlayerObjectHealth = new PlayerObjectHealth();

        PlayerObjectHealthService = new PlayerObjectHealthManager();
    }

    private void Start()
    {
        PlayerObjectPooling.Instance.PlayerObjectPoolingService.AddPlayerObjectToList(this,PlayerObjectPooling.Instance.PlayerObjectList);
    }
    
}
