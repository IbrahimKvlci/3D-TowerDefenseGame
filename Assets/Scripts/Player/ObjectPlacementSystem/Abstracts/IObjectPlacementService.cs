using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPlacementService
{
    void SetObjectToPlace(Player player, PlayerObject objectToPlaceNew);
    void PlaceObject(Player player, PlayerObject objectToPlace);
    void HandlePlacingObjectPlacement( PlayerObject playerObjectToPlace,Vector3 position);
    public void ClearObjectToPlaceBase(Player player);
}
