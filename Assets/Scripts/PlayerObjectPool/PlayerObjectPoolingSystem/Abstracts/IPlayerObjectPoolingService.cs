using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerObjectPoolingService
{
    public event EventHandler<OnObjectRemovedFromListEventArgs> OnObjectRemovedFromList;
    public class OnObjectRemovedFromListEventArgs : EventArgs
    {
        public PlayerObject playerObject;
    }

    public void AddPlayerObjectToList(PlayerObject playerObject, List<PlayerObject> playerObjectList);
    public void RemovePlayerObjectOnList(PlayerObject playerObject, List<PlayerObject> playerObjectList);
}
