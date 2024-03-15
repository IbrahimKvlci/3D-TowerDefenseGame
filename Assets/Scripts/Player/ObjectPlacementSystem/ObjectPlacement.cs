using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPlacement:MonoBehaviour
{
    [SerializeField] private LayerMask planeLayer;
    [SerializeField] private PlayerObject playerObject;
    [SerializeField] private GridPlacement gridPlacement;

    private PlayerObject _playerObjectToPlace;
    public PlayerObject PlayerObjectToPlace
    {
        get { return _playerObjectToPlace; }
        set { _playerObjectToPlace = value; }
    }

    private IObjectPlacementService _objectPalcementService;
    private IGridPlacementService _gridPlacementService;
    private IInputService _inputService;

    [Inject]
    public void Construct(IObjectPlacementService objectPlacementService,IGridPlacementService gridPlacementService,IInputService inputService)
    {
        _objectPalcementService= objectPlacementService;
        _gridPlacementService= gridPlacementService;
        _inputService= inputService;
    }

    private void Awake()
    {
        PlayerObjectToPlace = playerObject;
    }

    private void Update()
    {
        if(PlayerObjectToPlace != null)
        {
            //Player has object to place
            Vector3 playerObjectPos = _gridPlacementService.GetGridCellPositionByMousePosition(gridPlacement, planeLayer);
            _objectPalcementService.HandlePlacingObjectPlacement(PlayerObjectToPlace,playerObjectPos,planeLayer);

            Debug.Log(_inputService.MouseLeftKeyDown());
            if (_inputService.MouseLeftKeyDown())
            {
                _objectPalcementService.PlaceObject(ref _playerObjectToPlace);
            }
        }
    }

    
}
