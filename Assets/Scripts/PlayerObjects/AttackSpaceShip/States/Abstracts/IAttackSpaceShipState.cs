using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackSpaceShipState
{
    void EnterState();
    void UpdateState();
    void ExitState();
}
