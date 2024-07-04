using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : IEnemyHealthService
{
    public event EventHandler OnEnemyDamaged;

    public void DestroySelf(Enemy enemy)
    {
        GameObject.Destroy(enemy.gameObject);
    }

    public void TakeDamage(Enemy enemy, float damage)
    {
        OnEnemyDamaged?.Invoke(this, EventArgs.Empty);

        enemy.EnemyHealth.Health -= damage;
        if (enemy.EnemyHealth.Health <= 0)
        {
            enemy.EnemyHealth.IsDead = true;
        }
    }
}
