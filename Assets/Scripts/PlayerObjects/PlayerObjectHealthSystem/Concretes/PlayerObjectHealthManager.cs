using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectHealthManager : IPlayerObjectHealthService
{
    public void DestroySelf(PlayerObject playerObject)
    {
        PlayerObjectPooling.Instance.PlayerObjectList.Remove(playerObject);
        GameObject.Destroy(playerObject.gameObject);
    }

    public void TakeDamage(PlayerObject playerObject, float damage)
    {
        playerObject.PlayerObjectHealth.Health-=damage;
        if(playerObject.PlayerObjectHealth.Health <= 0 )
        {
            playerObject.PlayerObjectHealth.IsDead = true;
        }
    }
}
