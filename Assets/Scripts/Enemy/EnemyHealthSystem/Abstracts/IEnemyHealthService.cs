using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyHealthService
{
    event EventHandler OnEnemyDamaged;

    void DestroySelf(Enemy enemy);
    void TakeDamage(Enemy enemy, float damage);
}
