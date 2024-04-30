using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackSpaceShipMovementService
{
    void MoveToPoint(AttackSpaceShip attackSpaceShip,Vector3 pointToMove, float speed);
    bool RandomPoint(Vector3 center, float range, out Vector3 result);
}
