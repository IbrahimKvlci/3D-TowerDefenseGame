using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

public abstract class Enemy : MonoBehaviour
{
    [field:SerializeField] public EnemySO EnemySO {  get; set; }
    [field:SerializeField] public EnemyTriggerController EnemyTriggerController { get; set; }

    public PlayerObject PlayerObjectTarget { get; set; }
    public EnemyMovement EnemyMovement { get; set; }

    public IEnemyStateService EnemyStateService { get; set; }

    public IEnemyState EnemyTriggerState { get; set; }
    public IEnemyState EnemyMoveState { get; set; }
    public IEnemyState EnemyAttackState { get; set; }
    public IEnemyState EnemyPrepareAttackState { get; set; }

    private IEnemyMovementService _enemyMovementService;
    private IEnemyDetectPlayerObjectService _enemyDetectPlayerObjectService;
    private IEnemyAttackService _enemyAttackService;

    [Inject]
    public void Construct(IEnemyMovementService enemyMovementService, IEnemyDetectPlayerObjectService enemyDetectPlayerObjectService,IEnemyAttackService enemyAttackService)
    {
        _enemyMovementService = enemyMovementService;
        _enemyDetectPlayerObjectService = enemyDetectPlayerObjectService;
        _enemyAttackService = enemyAttackService;
    }

    private void Awake()
    {
        EnemyMovement=new EnemyMovement(GetComponent<NavMeshAgent>());

        EnemyStateService = new EnemyStateManager();

        EnemyMoveState = new EnemyMoveState(this,EnemyStateService,_enemyMovementService);
        EnemyAttackState = new EnemyAttackState(this,EnemyStateService,_enemyAttackService);
        EnemyTriggerState = new EnemyTriggerState(this, EnemyStateService,_enemyDetectPlayerObjectService);
        EnemyPrepareAttackState = new EnemyPrepareAttackState(this, EnemyStateService);
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
