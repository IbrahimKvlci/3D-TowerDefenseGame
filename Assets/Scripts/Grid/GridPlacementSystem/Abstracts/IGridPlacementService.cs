using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGridPlacementService
{
    Vector3 GetGridCellPositionByMousePosition(GridPlacement gridPlacement,LayerMask planeLayer);
}
