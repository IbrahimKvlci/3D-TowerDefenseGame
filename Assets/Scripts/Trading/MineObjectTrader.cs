using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObjectTrader : MonoBehaviour
{
    [field:SerializeField] public MineObject MineObject { get; set; }

    public float USDParity { get; set; }
    public float SellingCountEachDay { get; set; } = 0;
    public List<float> PriceHistory { get; set; }= new List<float>();

    virtual protected void Start()
    {
        AddNewPrice(MineObject.MineObjectSO.startingPrice);
    }

    public void AddNewPrice(float price)
    {
        PriceHistory.Add(price);
        USDParity = price;
    }
}
