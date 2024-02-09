using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMovementBase))]
public class EnemyBattle : MonoBehaviour
{
    [SerializeField] private EnemySO enemySO;

    private EnemyMovementBase enemyMovementBase;

    private float attackTimer;


    private void Awake()
    {
        enemyMovementBase= GetComponent<EnemyMovementBase>();
    }

    private void Update()
    {
        if(Physics.Raycast(transform.position,transform.forward,out RaycastHit hit, enemySO.attackRange))
        {
            //Hit gameObject
            if(hit.transform.TryGetComponent<PlayerObjectHealth>(out PlayerObjectHealth playerObjectHealth))
            {
                //Object is player-object-health
                enemyMovementBase.SetCanMove(false);
                attackTimer += Time.deltaTime;
                if(attackTimer >= enemySO.attackSpeed)
                {
                    attackTimer = 0;
                    Attack(playerObjectHealth, enemySO.damage);
                    Debug.Log(playerObjectHealth.Health);
                }
            }
            else
            {
                //Object is not player-object-health
                enemyMovementBase.SetCanMove(true);
            }
        }
        else
        {
            //It didn't hit any object
            enemyMovementBase.SetCanMove(true);
        }
    }

    private void Attack(IDamageable damageable, float damage)
    {
        damageable.TakeDamage(damage);
    }
}
