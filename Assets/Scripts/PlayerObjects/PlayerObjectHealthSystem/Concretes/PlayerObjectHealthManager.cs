using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectHealthManager : IPlayerObjectHealthService
{
    public void DestroySelf(PlayerObject playerObject)
    {
        GameObject.Destroy(playerObject.gameObject);
    }

    public void TakeDamage(PlayerObjectHealth playerObjectHealth, float damage)
    {
        playerObjectHealth.Health-=damage;
    }
}
