using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerStateService
{
    public IPlayerState CurrentPlayerState { get; set; }

    void Initialize(IPlayerState state);
    void SwitchState(IPlayerState state);
}
