using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPlacementService
{
    void SetObjectToPlace(ref PlayerObject objectToPlaceBase, PlayerObject objectToPlaceNew);
    void PlaceObject(ref PlayerObject objectToPlace);
    void HandlePlacingObjectPlacement( PlayerObject playerObjectToPlace,Vector3 position, LayerMask planeLayer);
}
