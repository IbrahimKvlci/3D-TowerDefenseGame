using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineWorkingManager : IMineWorkingService
{


    public void RunTask(PlayerObject playerObject)
    {
        Debug.Log("Mine work!");
    }

    public void RunTask(PlayerObject playerObject, Player player)
    {
        ((Mine)playerObject).MineStateService.SwitchState(((Mine)playerObject).MineMiningState);

    }
}
