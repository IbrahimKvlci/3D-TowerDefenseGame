using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class EnemyMovementBase : MonoBehaviour
{
    private PlayerObjectsBase target;
    private NavMeshAgent agent;

    private IPlayerObjectPoolingSystem _playerObjectPoolingSystem;

    private bool canMove;

    [Inject]
    public void Construct(IPlayerObjectPoolingSystem playerObjectPoolingSystem)
    {
        _playerObjectPoolingSystem = playerObjectPoolingSystem;
    }

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        SetCanMove(true);
        _playerObjectPoolingSystem.OnObjectRemovedFromList += playerObjectPoolingSystem_OnObjectRemovedFromList;
    }

    private void playerObjectPoolingSystem_OnObjectRemovedFromList(object sender, IPlayerObjectPoolingSystem.OnObjectRemovedFromListEventArgs e)
    {
        if (target == e.playerObject)
        {
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
        List<PlayerObjectsBase> playerObjects = _playerObjectPoolingSystem.GetPlayerObjects();
        if (playerObjects.Count == 0)
        {
            return null;
        }
        PlayerObjectsBase playerObjectToFollow = playerObjects[0];
        for (int i = 1; i < playerObjects.Count; i++)
        {
            float distanceEnemyAndFirstDamageable = Vector3.Distance(this.transform.position, playerObjectToFollow.transform.position);
            float distanceEnemyAndSecondDamageable = Vector3.Distance(this.transform.position, playerObjects[i].transform.position);

            if (distanceEnemyAndSecondDamageable < distanceEnemyAndFirstDamageable)
            {
                //New closest player object was found
                playerObjectToFollow = playerObjects[i];
            }
        }

        return playerObjectToFollow;
    }

    public bool GetCanMove()
    {
        return canMove;
    }

    public void SetCanMove(bool value)
    {
        canMove = value;

        agent.isStopped = !canMove;
    }
}
