using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [field:SerializeField] public EnemySO EnemySO {  get; set; }
    [field:SerializeField] public EnemyTriggerController EnemyTriggerController { get; set; }

    public PlayerObject PlayerObjectTarget { get; set; }
    public EnemyMovement EnemyMovement { get; set; }

    public IEnemyStateService EnemyStateService { get; set; }
    public IEnemyDetectPlayerObjectService EnemyTriggerService { get; set; }
    public IEnemyMovementService EnemyMovementService { get; set; }

    public IEnemyState EnemyTriggerState { get; set; }
    public IEnemyState EnemyMoveState { get; set; }
    public IEnemyState EnemyAttackState { get; set; }


    private void Awake()
    {
        EnemyMovement=new EnemyMovement();

        EnemyTriggerService = new EnemyDetectPlayerObjectManager();
        EnemyStateService = new EnemyStateManager();
        EnemyMovementService = new EnemyMovementManager(GetComponent<NavMeshAgent>());

        EnemyMoveState = new EnemyMoveState(this,EnemyStateService);
        EnemyAttackState = new EnemyAttackState(this,EnemyStateService);
        EnemyTriggerState = new EnemyTriggerState(this, EnemyStateService,EnemyTriggerService);
    }

    private void Start()
    {
        EnemyStateService.Initialize(EnemyTriggerState);
    }

    private void Update()
    {
        EnemyStateService.CurrentEnemyState.UpdateState();
    }
}
