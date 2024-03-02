using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyAttackService
{
    void Attack(PlayerObject playerObject,float damage);
}
