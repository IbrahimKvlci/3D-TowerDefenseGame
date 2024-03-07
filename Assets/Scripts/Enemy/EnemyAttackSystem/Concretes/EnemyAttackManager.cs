using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : IEnemyAttackService
{
    public void Attack(PlayerObject playerObject, float damage)
    {
        playerObject.PlayerObjectHealthService.TakeDamage(playerObject, damage);
        Debug.Log(playerObject.PlayerObjectHealth.Health);
    }
}
