using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [field: SerializeField] public RocketSO RocketSO { get; set; }

    [SerializeField] private LayerMask layerMask;

    public Enemy EnemyTarget { get; set; }

    private float movementTimer;
    private Vector3 spawnPos;
    private Vector3 enemyLastPoint;

    private bool isCollided;

    private IEnemyHealthService _enemyHealthService;

    private void Awake()
    {
        _enemyHealthService = InGameIoC.Instance.EnemyHealthService;
    }

    private void Start()
    {
        isCollided = false;
        movementTimer = 0;
        spawnPos = transform.position;
    }

    private void Update()
    {
        HandleRocketMovement();

        if (isCollided)
        {
            foreach (Enemy enemy in TriggerEnemyTool.GetAllTriggeredEnemies(transform, RocketSO.damageRadius, layerMask))
            {
                _enemyHealthService.TakeDamage(enemy, RocketSO.damage);
            }
            Destroy(gameObject);
        }
    }

    private void HandleRocketMovement()
    {
        if(EnemyTarget!=null)
            enemyLastPoint = EnemyTarget.transform.position;

        movementTimer += Time.deltaTime;
        float percentageComplete = movementTimer / RocketSO.rocketArrivalTime;

        transform.position = Vector3.Lerp(spawnPos, enemyLastPoint, percentageComplete);

        transform.LookAt(enemyLastPoint);

        if (percentageComplete >= 1)
        {
            isCollided = true;
        }


    }
}
