using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretState
{
    void EnterState();
    void UpdateState();
    void ExitState();
}
