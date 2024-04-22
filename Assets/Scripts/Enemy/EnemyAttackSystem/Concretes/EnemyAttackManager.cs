using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackManager : IEnemyAttackService
{
    protected private IPlayerObjectHealthService _playerObjectHealthService;

    public EnemyAttackManager(IPlayerObjectHealthService playerObjectHealthService)
    {
        _playerObjectHealthService=playerObjectHealthService;
    }

    public void Attack(PlayerObject playerObject, float damage)
    {
        _playerObjectHealthService.TakeDamage(playerObject, damage);
        Debug.Log(playerObject.PlayerObjectHealth.Health);
    }


}
