using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public abstract class PlayerObject : MonoBehaviour
{

    public PlayerObjectHealth PlayerObjectHealth { get; set; }

    public IPlayerObjectHealthService PlayerObjectHealthService { get; private set; }

    public IPlayerObjectStateService PlayerObjectStateService { get; set; }

    public IPlayerObjectState PlayerObjectHoldingState { get; set; }
    public IPlayerObjectState PlayerObjectPlacingState { get; set; }
    public IPlayerObjectState PlayerObjectPlacedState { get; set; }
    public IPlayerObjectState PlayerObjectDestroyState { get; set; }


    private void Awake()
    {
        PlayerObjectHealth = new PlayerObjectHealth();
        PlayerObjectHealthService = new PlayerObjectHealthManager();
        PlayerObjectStateService = new PlayerObjectStateManager();

        PlayerObjectHoldingState = new PlayerObjectHoldingState(this,PlayerObjectStateService);
        PlayerObjectPlacingState = new PlayerObjectPlacingState(this,PlayerObjectStateService);
        PlayerObjectPlacedState = new PlayerObjectPlacedState(this,PlayerObjectStateService);
        PlayerObjectDestroyState = new PlayerObjectDestroyState(this,PlayerObjectStateService);
    }

    private void Start()
    {
        PlayerObjectStateService.Initialize(PlayerObjectHoldingState);
    }

    private void Update()
    {
        PlayerObjectStateService.CurrentPlayerObjectState.UpdateState();
    }

}
