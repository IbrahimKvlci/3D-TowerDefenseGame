using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class EnemyMovementBase : MonoBehaviour
{
    private PlayerObjectsBase target;
    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        PlayerObjectPoolingSystem.Instance.OnObjectRemovedFromList += PlayerObjectPoolingSystem_OnObjectRemovedFromList;
    }

    private void PlayerObjectPoolingSystem_OnObjectRemovedFromList(object sender, PlayerObjectPoolingSystem.OnObjectRemovedFromListEventArgs e)
    {
        if (target == e.playerObject)
        {
            Debug.Log("esit");
            target = GetClosestPlayerObject();
        }
    }

    private void Update()
    {
        HandleMovement();
    }

    protected virtual void HandleMovement()
    {
        if (target == null)
        {
            target = GetClosestPlayerObject();
        }
        else
        {
            agent.destination = target.transform.position;
        }
    }

    protected virtual PlayerObjectsBase GetClosestPlayerObject()
    {
        List<PlayerObjectsBase> playerObjects = PlayerObjectPoolingSystem.Instance.GetPlayerObjects();
        if (playerObjects.Count == 0)
        {
            return null;
        }
        PlayerObjectsBase playerObjectToFollow = playerObjects[0];
        for (int i = 1; i < playerObjects.Count; i++)
        {
            float distanceEnemyAndFirstDamageable = Vector3.Distance(this.transform.position, playerObjectToFollow.transform.position);
            float distanceEnemyAndSecondDamageable = Vector3.Distance(this.transform.position, playerObjects[i].transform.position);

            if(distanceEnemyAndSecondDamageable < distanceEnemyAndFirstDamageable)
            {
                //New closest player object was found
                playerObjectToFollow = playerObjects[i];
            }
        }

        return playerObjectToFollow;
    }
}
