using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTriggerController : MonoBehaviour
{

    [SerializeField] private Enemy _enemy;
    [SerializeField] private LayerMask _layerMask;

    public IEnemyTriggerService EnemyTriggerService { get; set; }

    private void Awake()
    {
        EnemyTriggerService = new EnemyTriggerManager();
    }


    public bool IsPlayerObjectTriggeredToBeAttacked()
    {
        return EnemyTriggerService.IsPlayerObjectTriggeredToBeAttacked(transform,_enemy.PlayerObjectTarget, _enemy.EnemySO.attackRange, _layerMask);
    }
}
