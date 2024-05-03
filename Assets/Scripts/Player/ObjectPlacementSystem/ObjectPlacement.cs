using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ObjectPlacement:MonoBehaviour
{
    [field:SerializeField] public LayerMask PlaneLayer {  get;  set; }
    [SerializeField] private PlayerObject playerObject;
    [field:SerializeField] public GridPlacement GridPlacement {  get; set; }
    [SerializeField] private Player player;

    private PlayerObject _playerObjectToPlace;
    public PlayerObject PlayerObjectToPlace
    {
        get { return _playerObjectToPlace; }
        set { _playerObjectToPlace = value; }
    }

    private void Awake()
    {
        PlayerObjectToPlace = playerObject;
    }



    
}
