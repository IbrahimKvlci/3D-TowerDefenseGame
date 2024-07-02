using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPlacementService
{
    void SetObjectToPlace(Player player, PlayerObject objectToPlaceNew);
    void PlaceObject(Player player, PlayerObject objectToPlace);
    void HandlePlacingObjectPlacement( PlayerObject playerObjectToPlace,Vector3 position);
    void ClearObjectToPlaceBase(Player player);

    bool HasPlayerPlayerObjectToPlace( Player player );
}
