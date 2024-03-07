using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyMovementService
{
    void HandleMovement(Enemy enemy,PlayerObject target);
    void SetCanMove(Enemy enemy,bool canMove);
}
