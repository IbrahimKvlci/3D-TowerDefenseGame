using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class PlayerObject : MonoBehaviour
{

    [field:SerializeField] public PlayerObjectSO PlayerObjectSO { get; set; }
    [field: SerializeField] public Player Player { get; set; }

    public PlayerObjectHealth PlayerObjectHealth { get; set; }
    public bool IsPlaced { get; set; }

    private IPlayerObjectHealthService _playerObjectHealthService;

    public IPlayerObjectStateService PlayerObjectStateService { get; set; }
    public IPlayerObjectWorkingService PlayerObjectWorkingService { get; set; }

    public IPlayerObjectState PlayerObjectHoldingState { get; set; }
    public IPlayerObjectState PlayerObjectPlacingState { get; set; }
    public IPlayerObjectState PlayerObjectPlacedState { get; set; }
    public IPlayerObjectState PlayerObjectDestroyState { get; set; }


    //[Inject]
    //public void Construct(IPlayerObjectHealthService playerObjectHealthService)
    //{
    //    _playerObjectHealthService = playerObjectHealthService;
    //}

    protected virtual void Awake()
    {
        Player = Player.Instance;

        _playerObjectHealthService = new PlayerObjectHealthManager();

        PlayerObjectHealth = new PlayerObjectHealth();
        PlayerObjectStateService=new PlayerObjectStateManager();

        PlayerObjectStateService = new PlayerObjectStateManager();
        PlayerObjectHoldingState = new PlayerObjectHoldingState(this,PlayerObjectStateService);
        PlayerObjectPlacingState = new PlayerObjectPlacingState(this, PlayerObjectStateService);
        PlayerObjectPlacedState = new PlayerObjectPlacedState(this, PlayerObjectStateService);
        PlayerObjectDestroyState = new PlayerObjectDestroyState(this, PlayerObjectStateService,_playerObjectHealthService);
    }

    protected virtual void Start()
    {
        PlayerObjectHealth.Health = PlayerObjectSO.healthMax;
        PlayerObjectHealth.IsDead = false;
        IsPlaced = false;

        PlayerObjectStateService.Initialize(PlayerObjectHoldingState);
    }

    protected virtual void Update()
    {
        PlayerObjectStateService.CurrentPlayerObjectState.UpdateState();
    }

}
