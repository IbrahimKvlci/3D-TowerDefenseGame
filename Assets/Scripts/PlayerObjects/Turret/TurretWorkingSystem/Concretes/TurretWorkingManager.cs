using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretWorkingManager : ITurretWorkingService
{
    public void RunTask(PlayerObject playerObject)
    {
        throw new System.NotImplementedException();
    }

    public void RunTask(PlayerObject playerObject, Player player)
    {
        ((Turret)playerObject).TurretStateService.SwitchState(((Turret)playerObject).TurretTargetState);
    }
}
