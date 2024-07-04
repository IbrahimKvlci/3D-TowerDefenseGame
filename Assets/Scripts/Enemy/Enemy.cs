using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Enemy : MonoBehaviour
{
    [field:SerializeField] public EnemySO EnemySO {  get; set; }
    [field:SerializeField] public EnemyTriggerController EnemyTriggerController { get; set; }
    [field:SerializeField] public EnemyHealthController EnemyHealthController {  get; set; }

    public PlayerObject PlayerObjectTarget { get; set; }
    public EnemyMovement EnemyMovement { get; set; }
    public EnemyHealth EnemyHealth { get; set; }

    public IEnemyStateService EnemyStateService { get; set; }

    public IEnemyState EnemyTriggerState { get; set; }
    public IEnemyState EnemyMoveState { get; set; }
    public IEnemyState EnemyAttackState { get; set; }
    public IEnemyState EnemyPrepareAttackState { get; set; }
    public IEnemyState EnemyDestroyState { get; set; }

    protected private IEnemyMovementService _enemyMovementService;
    protected private IEnemyDetectPlayerObjectService _enemyDetectPlayerObjectService;
    protected private IEnemyAttackService _enemyAttackService;
    protected private IEnemyHealthService _enemyHealthService;


    private void Awake()
    {
        _enemyMovementService = InGameIoC.Instance.EnemyMovementService;
        _enemyDetectPlayerObjectService=InGameIoC.Instance.EnemyDetectPlayerObjectService;
        _enemyAttackService=InGameIoC.Instance.EnemyAttackService;
        _enemyHealthService = InGameIoC.Instance.EnemyHealthService;


        EnemyMovement=new EnemyMovement(GetComponent<NavMeshAgent>());
        EnemyHealth = new EnemyHealth();

        EnemyStateService = new EnemyStateManager();

        EnemyMoveState = new EnemyMoveState(this,EnemyStateService,_enemyMovementService);
        EnemyAttackState = new EnemyAttackState(this,EnemyStateService,_enemyAttackService);
        EnemyTriggerState = new EnemyTriggerState(this, EnemyStateService,_enemyDetectPlayerObjectService);
        EnemyPrepareAttackState = new EnemyPrepareAttackState(this, EnemyStateService);
        EnemyDestroyState = new EnemyDestroyState(this, EnemyStateService,_enemyHealthService);
    }

    private void Start()
    {
        EnemyHealth.IsDead = false;
        EnemyHealth.Health = EnemySO.maxHealth;

        EnemyStateService.Initialize(EnemyTriggerState);
    }

    private void Update()
    {
        EnemyStateService.CurrentEnemyState.UpdateState();
    }

    public void ClearPlayerObjectTarget()
    {
        PlayerObjectTarget = null;
    }
}
