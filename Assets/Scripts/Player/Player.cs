using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }

    [field:SerializeField] public PlayerInfo PlayerInfo { get; set; }
    [field:SerializeField] public ObjectPlacement ObjectPlacement { get; set; }
    [field:SerializeField] public PlayerShopping PlayerShopping { get; set; }
    [field: SerializeField] public PlayerUpgrading PlayerUpgrading { get; set; }

    public IPlayerState PlayerMenuState { get; set; }
    public IPlayerState PlayerIdleState {  get; set; }
    public IPlayerState PlayerHoldingObjectState {  get; set; }

    public IPlayerStateService PlayerStateService { get; set; }



    private void Awake()
    {
        if (Instance != null) { 
            Destroy(this);
        }
        Instance= this;
        DontDestroyOnLoad(this.gameObject);

        PlayerStateService = new PlayerStateManager();

        PlayerIdleState = new PlayerIdleState(this, PlayerStateService);
        PlayerMenuState=new PlayerMenuState(this,PlayerStateService);
    }

    private void Start()
    {
        PlayerStateService.Initialize(PlayerMenuState);
    }

    private void Update()
    {
        PlayerStateService.CurrentPlayerState.UpdateState();
    }
}
