using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPlacement:MonoBehaviour
{
    [SerializeField] private LayerMask planeLayer;
    [SerializeField] private PlayerObject playerObject;

    public PlayerObject PlayerObjectToPlace { get; set; }

    private IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    private void Awake()
    {
        PlayerObjectToPlace = playerObject;
    }

    private void Update()
    {
        HandlePlacingObjectPlacement();
    }

    private void HandlePlacingObjectPlacement()
    {
        if(PlayerObjectToPlace != null)
        {
            PlayerObjectToPlace.transform.position = _inputService.GetMousePositionOnAPlane(planeLayer);
        }
    }
}
