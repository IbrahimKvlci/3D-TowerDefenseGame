using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerObjectPoolingSystem
{
    public event EventHandler<OnObjectRemovedFromListEventArgs> OnObjectRemovedFromList;
    public class OnObjectRemovedFromListEventArgs : EventArgs
    {
        public PlayerObjectsBase playerObject;
    }

    public void AddPlayerObjectToList(PlayerObjectsBase playerObject);
    public void RemovePlayerObjectOnList(PlayerObjectsBase playerObject);
    public List<PlayerObjectsBase> GetPlayerObjects();
}
