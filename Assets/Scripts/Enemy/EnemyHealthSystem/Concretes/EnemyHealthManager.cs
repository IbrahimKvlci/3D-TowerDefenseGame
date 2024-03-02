using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : IEnemyHealthService
{
    public void DestroySelf(Enemy enemy)
    {
        GameObject.Destroy(enemy.gameObject);
    }

    public void TakeDamage(EnemyHealth enemyHealth, float damage)
    {
        enemyHealth.Health -= damage;
    }
}
