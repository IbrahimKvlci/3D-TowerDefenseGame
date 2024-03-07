using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerObjectHealthService
{
    void DestroySelf(PlayerObject playerObject);
    void TakeDamage(PlayerObject playerObject,float damage);
}
