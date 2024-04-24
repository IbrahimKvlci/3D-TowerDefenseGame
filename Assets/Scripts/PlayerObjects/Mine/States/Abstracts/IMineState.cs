using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMineState
{
    void EnterState();
    void UpdateState();
    void ExitState();
}
