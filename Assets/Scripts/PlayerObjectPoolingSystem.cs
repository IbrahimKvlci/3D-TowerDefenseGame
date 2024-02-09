using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerObjectPoolingSystem : MonoBehaviour
{
    public event EventHandler<OnObjectRemovedFromListEventArgs> OnObjectRemovedFromList;
    public class OnObjectRemovedFromListEventArgs : EventArgs
    {
        public PlayerObjectsBase playerObject;
    }

    public static PlayerObjectPoolingSystem Instance { get; set; }

    private List<PlayerObjectsBase> playerObjects = new List<PlayerObjectsBase>();

    private void Awake()
    {
        Instance = this;
    }

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

        OnObjectRemovedFromList?.Invoke(this, new OnObjectRemovedFromListEventArgs
        {
            playerObject = playerObject
        });
    }

    public List<PlayerObjectsBase> GetPlayerObjects()
    {
        return playerObjects;
    }
}
