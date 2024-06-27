using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldTrader : MineObjectTrader
{
    protected override void Start()
    {
        base.Start();
        PriceHistory.Add(120);
        PriceHistory.Add(115);
        PriceHistory.Add(96);
    }
}
