using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPlacementManager : IObjectPlacementService
{
    public void PlaceObject(ObjectPlacement objectToPlace)
    {
        throw new System.NotImplementedException();
    }

    public void SetObjectToPlace(ref ObjectPlacement objectToPlaceBase,ObjectPlacement objectToPlaceNew)
    {
        if(objectToPlaceBase != null)
        {
            //Player has object
            ClearObjectToPlaceBase(ref objectToPlaceBase);
        }
        objectToPlaceBase= objectToPlaceNew;
    }

    private void ClearObjectToPlaceBase(ref ObjectPlacement objectToPlaceBase)
    {
        objectToPlaceBase=null;
    }
}
