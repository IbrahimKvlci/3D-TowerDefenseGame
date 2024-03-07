using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementManager : IEnemyMovementService
{

    public void HandleMovement(Enemy enemy, PlayerObject target)
    {
        enemy.EnemyMovement.NavMeshAgent.destination = target.transform.position;
    }

    public void SetCanMove(Enemy enemy, bool canMove)
    {
        enemy.EnemyMovement.CanMove = canMove;
        enemy.EnemyMovement.NavMeshAgent.isStopped = !canMove;
        enemy.EnemyMovement.NavMeshAgent.ResetPath();
    }
}
