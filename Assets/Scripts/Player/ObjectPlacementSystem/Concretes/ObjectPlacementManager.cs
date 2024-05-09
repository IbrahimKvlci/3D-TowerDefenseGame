using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementManager : IObjectPlacementService
{
    public void PlaceObject(Player player, PlayerObject objectToPlace)
    {
        objectToPlace.PlayerObjectStateService.SwitchState(objectToPlace.PlayerObjectPlacingState);
        player.ObjectPlacement.PlayerObjectToPlace = null;
    }

    /// <summary>
    /// Give new objectToPlace to player
    /// </summary>
    /// <param name="objectToPlaceBase"></param>
    /// <param name="objectToPlaceNew"></param>
    public void SetObjectToPlace(Player player, PlayerObject objectToPlaceNew)
    {
        if (player.ObjectPlacement.PlayerObjectToPlace != null)
        {
            ClearObjectToPlaceBase(player);
        }
        PlayerObject playerObject = GameObject.Instantiate(objectToPlaceNew);
        player.ObjectPlacement.PlayerObjectToPlace = playerObject;
    }

    public void HandlePlacingObjectPlacement(PlayerObject playerObjectToPlace,Vector3 position)
    {

        playerObjectToPlace.transform.position = position;

    }

    public void ClearObjectToPlaceBase( Player player)
    {
        GameObject.Destroy(player.ObjectPlacement.PlayerObjectToPlace.gameObject);
        player.ObjectPlacement.PlayerObjectToPlace = null;
    }
}
