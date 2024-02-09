using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private EnemySO enemySO;

    public float Health { get; set; }

    private void Start()
    {
        Health = enemySO.maxHealth;
    }

    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        Health -= damage;

        if (Health<0)
        {
            DestroySelf();
        }
    }
}
