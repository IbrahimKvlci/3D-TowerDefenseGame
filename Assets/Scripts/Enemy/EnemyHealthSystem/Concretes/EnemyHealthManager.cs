using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : IEnemyHealthService
{
    public event EventHandler OnEnemyDamaged;
    public event EventHandler OnEnemyDead;

    public void DestroySelf(Enemy enemy)
    {
        GameObject.Destroy(enemy.gameObject);
    }

    public void TakeDamage(Enemy enemy, float damage)
    {
        OnEnemyDamaged?.Invoke(enemy, EventArgs.Empty);

        enemy.EnemyHealth.Health -= damage;
        if (enemy.EnemyHealth.Health <= 0)
        {
            enemy.EnemyHealth.IsDead = true;

            OnEnemyDead?.Invoke(this, EventArgs.Empty);
        }
    }
}
