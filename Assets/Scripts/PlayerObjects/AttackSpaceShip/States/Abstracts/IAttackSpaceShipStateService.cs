using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttackSpaceShipStateService
{
    public IAttackSpaceShipState CurrentAttackSpaceShipState { get; set; }

    void Initialize(IAttackSpaceShipState state);
    void SwitchState(IAttackSpaceShipState state);
}
