using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathDragonVisualController : EnemyVisualController
{
    [SerializeField] private GameObject fireBreathParticle;

    private float timer = 0;
    private bool isAttackStarted;
    private bool isParticleStarted;

    protected override void Start()
    {
        base.Start();

        isAttackStarted=false;
    }

    protected override void EnemyVisualController_OnEnemyAttackStarted(object sender, EventArgs e)
    {
        base.EnemyVisualController_OnEnemyAttackStarted(sender, e);

        isAttackStarted = true;
        isParticleStarted = false;
    }

    private void Update()
    {
        if(isAttackStarted)
        {
            timer += Time.deltaTime;
            if(timer > enemy.EnemyVisualController.EnemyAnimationSO.attackAnimationPreparingTimerMax)
            {
                timer = 0;
                isAttackStarted = false;

                ShowParticle(fireBreathParticle);
                isParticleStarted = true;
            }
        }

        if (isParticleStarted)
        {
            timer += Time.deltaTime;
            if(timer > enemy.EnemyVisualController.EnemyAnimationSO.attackAnimationDurationTimerMax)
            {
                timer = 0;
                isParticleStarted = false;

                HideParticle(fireBreathParticle);
            }
        }
    }

    private void ShowParticle(GameObject particle)
    {
        particle.SetActive(true);
    }

    private void HideParticle(GameObject particle)
    {
        particle.SetActive(false);
    }
}
