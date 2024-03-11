using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectPlacementService
{
    void SetObjectToPlace(ref ObjectPlacement objectToPlaceBase, ObjectPlacement objectToPlaceNew);
    void PlaceObject(ObjectPlacement objectToPlace);
}
