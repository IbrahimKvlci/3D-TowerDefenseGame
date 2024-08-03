using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class MineObjectTrader : MonoBehaviour
{
    public event EventHandler OnAddingNewPrice;

    [field:SerializeField] public MineObject MineObject { get; set; }

    public float USDParity { get; set; }
    public float SellingCountEachDay { get; set; } = 0;
    [field:SerializeField] public List<float> PriceHistory { get; set; }/*= new List<float>();*/

    //virtual protected void Start()
    //{
    //    AddNewPrice(MineObject.MineObjectSO.startingPrice);
    //}

    public void AddNewPrice(float price)
    {
        PriceHistory.Add(price);
        USDParity = price;

        OnAddingNewPrice?.Invoke(this,EventArgs.Empty);
    }
}
