using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerObjectWorkingService
{
    void RunTask(PlayerObject playerObject);
    void RunTask(PlayerObject playerObject,Player player);

}
