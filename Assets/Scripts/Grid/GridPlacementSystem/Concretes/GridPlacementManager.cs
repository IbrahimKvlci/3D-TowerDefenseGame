using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlacementManager : IGridPlacementService
{
    private IInputService _inputService;

    public GridPlacementManager(IInputService inputService)
    {
        _inputService = inputService;
    }

    public Vector3 GetGridCellPositionByMousePosition(GridPlacement gridPlacement,LayerMask planeLayer)
    {
        Vector3 mousePos = _inputService.GetMousePositionOnAPlane(planeLayer);
        Vector3Int gridPos=gridPlacement.Grid.WorldToCell(mousePos);

        return gridPlacement.Grid.CellToWorld(gridPos);
    }
}
