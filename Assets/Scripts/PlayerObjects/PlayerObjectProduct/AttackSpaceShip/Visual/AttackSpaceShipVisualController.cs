using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipVisualController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private AttackSpaceShip attackSpaceShip;

    [SerializeField] private float muzzleFlashTimer;

    private float timer;
    private bool isAttackStarted;

    enum AttackSpaceShipAnimatorEnum
    {
        IsRunning,
        IsShooting,
        Shoot,
        OnFreezingFinished,
    }

    private void Start()
    {
        ((AttackSpaceShipFreezingState)attackSpaceShip.AttackSpaceShipFreezingState).OnFreezingFinished += AttackSpaceShipVisualController_OnFreezingFinished;
        ((AttackSpaceShipChaseState)attackSpaceShip.AttackSpaceShipChaseState).OnAttackSpaceShipChase += AttackSpaceShipVisualController_OnAttackSpaceShipChase;
        ((AttackSpaceShipChaseState)attackSpaceShip.AttackSpaceShipChaseState).OnAttackSpaceShipChaseFinished += AttackSpaceShipVisualController_OnAttackSpaceShipChaseFinished;
        ((AttackSpaceShipAttackState)attackSpaceShip.AttackSpaceShipAttackState).OnAttackSpaceShipAttack += AttackSpaceShipVisualController_OnAttackSpaceShipAttack;
        ((AttackSpaceShipAttackState)attackSpaceShip.AttackSpaceShipAttackState).OnAttackSpaceShipTarget += AttackSpaceShipVisualController_OnAttackSpaceShipTarget;
        ((AttackSpaceShipAttackState)attackSpaceShip.AttackSpaceShipAttackState).OnAttackSpaceShipAttackFinished += AttackSpaceShipVisualController_OnAttackSpaceShipAttackFinished;
    }

    private void Update()
    {
        if (isAttackStarted)
        {
            attackSpaceShip.MuzzleFlashParticleEffect.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= muzzleFlashTimer)
            {
                timer= 0;
                attackSpaceShip.MuzzleFlashParticleEffect.SetActive(false);
                isAttackStarted = false;
            }
        }
    }

    private void AttackSpaceShipVisualController_OnFreezingFinished(object sender, System.EventArgs e)
    {
        SetAttackSpaceShipAnimatorTrigger(AttackSpaceShipAnimatorEnum.OnFreezingFinished);
    }

    private void AttackSpaceShipVisualController_OnAttackSpaceShipChaseFinished(object sender, System.EventArgs e)
    {
        SetAttackSpaceShipAnimatorBool(AttackSpaceShipAnimatorEnum.IsRunning,false);
    }

    private void AttackSpaceShipVisualController_OnAttackSpaceShipAttackFinished(object sender, System.EventArgs e)
    {
        SetAttackSpaceShipAnimatorBool(AttackSpaceShipAnimatorEnum.IsShooting, false);
    }

    private void AttackSpaceShipVisualController_OnAttackSpaceShipTarget(object sender, System.EventArgs e)
    {
        SetAttackSpaceShipAnimatorBool(AttackSpaceShipAnimatorEnum.IsShooting,true);
    }

    private void AttackSpaceShipVisualController_OnAttackSpaceShipAttack(object sender, System.EventArgs e)
    {
        SetAttackSpaceShipAnimatorTrigger(AttackSpaceShipAnimatorEnum.Shoot);
        isAttackStarted = true;
    }

    private void AttackSpaceShipVisualController_OnAttackSpaceShipChase(object sender, System.EventArgs e)
    {
        SetAttackSpaceShipAnimatorBool(AttackSpaceShipAnimatorEnum.IsRunning, true);
    }

    private void SetAttackSpaceShipAnimatorBool(AttackSpaceShipAnimatorEnum attackSpaceShipAnimatorEnum,bool value)
    {
        animator.SetBool(attackSpaceShipAnimatorEnum.ToString(), value);
    }


    private void SetAttackSpaceShipAnimatorTrigger(AttackSpaceShipAnimatorEnum attackSpaceShipAnimatorEnum)
    {
        animator.SetTrigger(attackSpaceShipAnimatorEnum.ToString());
    }
}
