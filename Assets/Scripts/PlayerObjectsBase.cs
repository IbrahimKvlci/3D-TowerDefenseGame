using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerObjectsBase : MonoBehaviour, IDamageable
{
    

    public Transform GetTransform()
    {
        return transform;
    }

    private void Awake()
    {
        PlayerObjectPoolingSystem.Instance.AddPlayerObjectToList(this);
    }


    public void DestroySelf()
    {
        PlayerObjectPoolingSystem.Instance.RemovePlayerObjectOnList(this);
        Destroy(this.gameObject);
    }

    public void TakeDamage(float damage)
    {
        Debug.Log($"{this.name} has damaged {damage}");
    }
}
