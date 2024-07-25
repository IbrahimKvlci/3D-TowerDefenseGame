using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballDragonVisualController : EnemyVisualController
{
    [SerializeField] private GameObject fireballPrefab;
    [SerializeField] private Transform fireballStartingTransform;

    private GameObject fireball;
    private Vector3 firebalCreatedPos;

    private float movementTimer;
    private float visualTimer;

    protected override void EnemyVisualController_OnEnemyAttackStarted(object sender, EventArgs e)
    {
        base.EnemyVisualController_OnEnemyAttackStarted(sender, e);

        ShootFireball(out this.fireball);
        Debug.Log(fireball.name);
    }

    protected override void EnemyVisualController_OnEnemyAttackFinished(object sender, EventArgs e)
    {
        base.EnemyVisualController_OnEnemyAttackFinished(sender, e);

        DestroyFireball(fireball);
    }

    protected override void Update()
    {
        base.Update();

        HandleFireballMovement();
    }

    private void ShootFireball(out GameObject fireball)
    {
        fireball=Instantiate(fireballPrefab,fireballStartingTransform.position,Quaternion.identity);
        firebalCreatedPos=fireball.transform.position;
        fireball.SetActive(false);
    }

    private void DestroyFireball(GameObject fireball)
    {
        Destroy(fireball);
        this.fireball= null;
    }

    private void HandleFireballMovement()
    {
        if (fireball != null)
        {
            visualTimer += Time.deltaTime;
            if (visualTimer >= enemy.EnemyVisualController.EnemyAnimationSO.attackAnimationPreparingTimerMax)
            {
                fireball.SetActive(true);

                movementTimer += Time.deltaTime;
                float percentageComplete = movementTimer / enemy.EnemyVisualController.EnemyAnimationSO.attackAnimationToAttackTimerMax;

                fireball.transform.position = Vector3.Lerp(firebalCreatedPos, enemy.PlayerObjectTarget.transform.position, percentageComplete);
            }

            
        }
        else
        {
            movementTimer = 0;
            visualTimer = 0;
        }
    }


}
