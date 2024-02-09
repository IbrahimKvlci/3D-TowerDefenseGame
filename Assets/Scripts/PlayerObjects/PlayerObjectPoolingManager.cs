using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerObjectPoolingManager:IPlayerObjectPoolingSystem 
{
    public event EventHandler<IPlayerObjectPoolingSystem.OnObjectRemovedFromListEventArgs> OnObjectRemovedFromList;


    private List<PlayerObjectsBase> playerObjects = new List<PlayerObjectsBase>();


    public void AddPlayerObjectToList(PlayerObjectsBase playerObject)
    {
        if (!playerObjects.Contains(playerObject))
        {
            playerObjects.Add(playerObject);
        }
    }

    public void RemovePlayerObjectOnList(PlayerObjectsBase playerObject)
    {
        playerObjects.Remove(playerObject);

        OnObjectRemovedFromList?.Invoke(this, new IPlayerObjectPoolingSystem.OnObjectRemovedFromListEventArgs
        {
            playerObject = playerObject
        });
    }

    public List<PlayerObjectsBase> GetPlayerObjects()
    {
        return playerObjects;
    }
}
