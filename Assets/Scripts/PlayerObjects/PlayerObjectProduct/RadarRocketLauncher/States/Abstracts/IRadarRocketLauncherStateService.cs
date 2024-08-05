using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRadarRocketLauncherState 
{
    void EnterState();
    void UpdateState();
    void ExitState();
}
