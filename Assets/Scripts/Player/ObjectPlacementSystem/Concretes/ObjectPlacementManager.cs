using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementManager : IObjectPlacementService
{
    public void PlaceObject(ref PlayerObject objectToPlace)
    {
        objectToPlace.PlayerObjectStateService.SwitchState(objectToPlace.PlayerObjectPlacingState);
        ClearObjectToPlaceBase(ref objectToPlace);
    }

    /// <summary>
    /// Give new objectToPlace to player
    /// </summary>
    /// <param name="objectToPlaceBase"></param>
    /// <param name="objectToPlaceNew"></param>
    public void SetObjectToPlace(ref PlayerObject objectToPlaceBase, PlayerObject objectToPlaceNew)
    {
        if (objectToPlaceBase != null)
        {
            //Player has object
            ClearObjectToPlaceBase(ref objectToPlaceBase);
        }
        objectToPlaceBase = objectToPlaceNew;
    }

    public void HandlePlacingObjectPlacement(PlayerObject playerObjectToPlace,Vector3 position,LayerMask planeLayer)
    {

        playerObjectToPlace.transform.position = position;

    }

    private void ClearObjectToPlaceBase(ref PlayerObject objectToPlaceBase)
    {
        Debug.Log(objectToPlaceBase);
        objectToPlaceBase = null;
    }
}
