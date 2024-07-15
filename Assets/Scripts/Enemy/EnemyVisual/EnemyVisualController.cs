using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisualController : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [SerializeField] private Animator animator;

    enum EnemyAnimationEnum
    {
        AttackTrigger,
        IsWalking
    }

    private void Start()
    {
        ((EnemyMoveState)(enemy.EnemyMoveState)).OnEnemyMoveStarted += EnemyVisualController_OnEnemyMoveStarted;
        ((EnemyMoveState)(enemy.EnemyMoveState)).OnEnemyMoveFinished += EnemyVisualController_OnEnemyMoveFinished;
        ((EnemyAttackState)(enemy.EnemyAttackState)).OnEnemyAttacked += EnemyVisualController_OnEnemyAttacked;
    }

    private void EnemyVisualController_OnEnemyAttacked(object sender, System.EventArgs e)
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
