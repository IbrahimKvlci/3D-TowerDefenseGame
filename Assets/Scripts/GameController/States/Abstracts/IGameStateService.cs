using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameStateService
{
    public IGameState CurrentGameState { get; set; }

    void Initialize(IGameState state);
    void SwitchState(IGameState state);
}
