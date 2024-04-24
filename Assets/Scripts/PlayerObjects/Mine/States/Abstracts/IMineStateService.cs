using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMineStateService
{
    public IMineState CurrentMineState { get; set; }

    void Initialize(IMineState state);
    void SwitchState(IMineState state);
}
