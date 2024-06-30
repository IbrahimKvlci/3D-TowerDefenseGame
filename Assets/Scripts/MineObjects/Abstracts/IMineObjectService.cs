using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMineObjectService
{
    void ResetMineObjectCurrentCount(MineObject mineObject);
    void GiveCollectedMineObjectToPlayer(MineObject mineObject,Player player);
}
