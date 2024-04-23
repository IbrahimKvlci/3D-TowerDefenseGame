using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : IEnemyHealthService
{
    public void DestroySelf(Enemy enemy)
    {
        GameObject.Destroy(enemy.gameObject);
    }

    public void TakeDamage(Enemy enemy, float damage)
    {
        enemy.EnemyHealth.Health -= damage;
        if (enemy.EnemyHealth.Health <= 0)
        {
            enemy.EnemyHealth.IsDead = true;
        }
    }
}
