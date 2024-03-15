using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerObjectState
{
    void EnterState();
    void UpdateState();
    void ExitState();
}
