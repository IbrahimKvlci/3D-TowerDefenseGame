using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisualController : MonoBehaviour
{
    [SerializeField] protected Enemy enemy;
    [SerializeField] private Animator animator;
    [field:SerializeField] public EnemyAnimationSO EnemyAnimationSO {  get; private set; }

    enum EnemyAnimationEnum
    {
        AttackTrigger,
        IsWalking
    }

    protected virtual void Start()
    {
        ((EnemyMoveState)(enemy.EnemyMoveState)).OnEnemyMoveStarted += EnemyVisualController_OnEnemyMoveStarted;
        ((EnemyMoveState)(enemy.EnemyMoveState)).OnEnemyMoveFinished += EnemyVisualController_OnEnemyMoveFinished;
        ((EnemyAttackState)(enemy.EnemyAttackState)).OnEnemyAttackStarted += EnemyVisualController_OnEnemyAttackStarted;
        ((EnemyAttackState)(enemy.EnemyAttackState)).OnEnemyAttackFinished += EnemyVisualController_OnEnemyAttackFinished;

    }

    protected virtual void Update()
    {
        
    }

    protected virtual void EnemyVisualController_OnEnemyAttackFinished(object sender, System.EventArgs e)
    {
    }

    protected virtual void EnemyVisualController_OnEnemyAttackStarted(object sender, System.EventArgs e)
    {
        TriggerEnemyAttackAnim();
    }

    private void EnemyVisualController_OnEnemyMoveFinished(object sender, System.EventArgs e)
    {
        SetWalking(false);
    }

    private void EnemyVisualController_OnEnemyMoveStarted(object sender, System.EventArgs e)
    {
        SetWalking(true);
    }

    private void TriggerEnemyAttackAnim()
    {
        animator.SetTrigger(EnemyAnimationEnum.AttackTrigger.ToString());
    }

    private void SetWalking(bool isWalking)
    {
        animator.SetBool(EnemyAnimationEnum.IsWalking.ToString(),isWalking);
    }
}
