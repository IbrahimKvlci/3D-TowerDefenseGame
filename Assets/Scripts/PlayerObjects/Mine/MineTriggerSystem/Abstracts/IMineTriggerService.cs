using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMineTriggerService
{
    bool IsMineAtMinePoint(Mine mine,LayerMask layerMask,out MinePoint minePoint);
}
