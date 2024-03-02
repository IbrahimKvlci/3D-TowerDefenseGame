using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyStateService
{
    public IEnemyState CurrentEnemyState { get; set; }

    void Initialize(IEnemyState state);
    void SwitchState(IEnemyState state);
}
