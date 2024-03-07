using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementManager : IEnemyMovementService
{
    private NavMeshAgent _navMeshAgent;

    public EnemyMovementManager(NavMeshAgent navMeshAgent)
    {
        _navMeshAgent = navMeshAgent;
    }

    public void HandleMovement(PlayerObject target)
    {
        _navMeshAgent.destination = target.transform.position;
    }

    public void SetCanMove(bool canMove)
    {
        
    }
}
