using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipAttackManager : IAttackSpaceShipAttackService
{
    private IEnemyHealthService _enemyHealthService;

    public AttackSpaceShipAttackManager(IEnemyHealthService enemyHealthService)
    {
        _enemyHealthService = enemyHealthService;
    }

    public void Attack(Enemy enemy, float damage)
    {
        _enemyHealthService.TakeDamage(enemy, damage);
    }
}
