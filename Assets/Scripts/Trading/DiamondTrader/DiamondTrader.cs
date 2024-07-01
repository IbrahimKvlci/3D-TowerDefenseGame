using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondTrader : MineObjectTrader
{


    protected override void Start()
    {
        base.Start();
        PriceHistory.Add(160);
        PriceHistory.Add(250);
        PriceHistory.Add(75);
    }
}
