using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerObjectHealth : MonoBehaviour, IDamageable
{
    public float Health { get; set; }

    private IPlayerObjectPoolingSystem _playerObjectPoolingSystem;

    [Inject]
    public void Construct(IPlayerObjectPoolingSystem playerObjectPoolingSystem)
    {
        _playerObjectPoolingSystem = playerObjectPoolingSystem;
    }

    public void DestroySelf()
    {
        _playerObjectPoolingSystem.RemovePlayerObjectOnList(gameObject.GetComponent<PlayerObjectsBase>());
        Destroy(this.gameObject);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{this.name} has damaged {damage}");
        Health -= damage;

        if (Health <= 0)
        {
            DestroySelf();
        }
    }
}
