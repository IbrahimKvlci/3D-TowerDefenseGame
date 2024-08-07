using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHealthService
{
    event EventHandler OnEnemyDamaged;
    event EventHandler OnEnemyDead;

    void DestroySelf(Enemy enemy);
    void TakeDamage(Enemy enemy, float damage);
}
