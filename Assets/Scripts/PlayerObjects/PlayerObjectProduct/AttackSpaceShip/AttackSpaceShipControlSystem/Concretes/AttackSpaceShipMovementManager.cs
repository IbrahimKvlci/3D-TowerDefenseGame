using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.AI;

public class AttackSpaceShipMovementManager : IAttackSpaceShipMovementService
{


    public void MoveToPoint(AttackSpaceShip attackSpaceShip, Vector3 pointToMove, float speed)
    {
        attackSpaceShip.GetComponent<NavMeshAgent>().isStopped = false;
        attackSpaceShip.GetComponent<NavMeshAgent>().destination = pointToMove;
        attackSpaceShip.GetComponent<NavMeshAgent>().speed = speed;
        Debug.Log("move");
    }

    public bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        while (true)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
    }

    public void Stop(AttackSpaceShip attackSpaceShip)
    {
        Debug.Log("stopppp");
        attackSpaceShip.GetComponent<NavMeshAgent>().isStopped = true;
        attackSpaceShip.GetComponent<NavMeshAgent>().speed=0;
        attackSpaceShip.GetComponent<NavMeshAgent>().ResetPath();
    }
}
