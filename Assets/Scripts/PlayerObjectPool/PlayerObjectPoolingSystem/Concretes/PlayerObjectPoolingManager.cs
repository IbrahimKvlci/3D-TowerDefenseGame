using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerObjectPoolingManager:IPlayerObjectPoolingService 
{
    public event EventHandler<IPlayerObjectPoolingService.OnObjectRemovedFromListEventArgs> OnObjectRemovedFromList;


    public void AddPlayerObjectToList(PlayerObject playerObject,List<PlayerObject> playerObjectList)
    {
        if (!playerObjectList.Contains(playerObject))
        {
            playerObjectList.Add(playerObject);
        }
    }

    public void RemovePlayerObjectOnList(PlayerObject playerObject, List<PlayerObject> playerObjectList)
    {
        playerObjectList.Remove(playerObject);

        OnObjectRemovedFromList?.Invoke(this, new IPlayerObjectPoolingService.OnObjectRemovedFromListEventArgs
        {
            playerObject = playerObject
        });
    }
}
