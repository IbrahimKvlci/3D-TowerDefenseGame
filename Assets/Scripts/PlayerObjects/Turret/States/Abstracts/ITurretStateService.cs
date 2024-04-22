using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITurretStateService
{
    public ITurretState CurrentTurretState { get; set; }

    void Initialize(ITurretState state);
    void SwitchState(ITurretState state);
}
