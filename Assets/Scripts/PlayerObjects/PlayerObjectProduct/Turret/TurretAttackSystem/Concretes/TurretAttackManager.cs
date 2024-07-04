using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAttackManager : ITurretAttackService
{

    protected private IEnemyHealthService _enemyHealthService;

    public TurretAttackManager(IEnemyHealthService enemyHealthService)
    {
        _enemyHealthService = enemyHealthService;
    }

   
    public void Attack(Enemy enemy, float damage)
    {

        _enemyHealthService.TakeDamage(enemy, damage);
    }
}
