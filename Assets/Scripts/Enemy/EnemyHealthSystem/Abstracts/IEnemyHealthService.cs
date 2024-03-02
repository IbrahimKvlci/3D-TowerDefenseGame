using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHealthService
{
    void DestroySelf(Enemy enemy);
    void TakeDamage(EnemyHealth enemyHealth, float damage);
}
