using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class PlayerObjectsBase : MonoBehaviour
{
    private IPlayerObjectPoolingSystem _playerObjectPoolingSystem;

    [Inject]
    public void Construct(IPlayerObjectPoolingSystem playerObjectPoolingSystem)
    {
        _playerObjectPoolingSystem = playerObjectPoolingSystem;
    }

    private void Start()
    {
        _playerObjectPoolingSystem.AddPlayerObjectToList(this);
    }
    
}
