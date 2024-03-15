using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlayerObjectStateService
{
    public IPlayerObjectState CurrentPlayerObjectState { get; set; }

    void Initialize(IPlayerObjectState state);
    void SwitchState(IPlayerObjectState state);
}
