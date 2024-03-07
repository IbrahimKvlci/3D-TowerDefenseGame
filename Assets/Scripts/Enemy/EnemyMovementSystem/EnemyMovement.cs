using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement
{
    public EnemyMovement(NavMeshAgent navMeshAgent)
    {
        NavMeshAgent = navMeshAgent;
    }

    public NavMeshAgent NavMeshAgent { get; set; }

    public bool CanMove { get; set; }
}
