using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObjectTrader : MonoBehaviour
{
    public MineObject MineObject { get; set; }

    public float USDParity { get; set; } = 100;
    public float SellingCountEachDay { get; set; } = 0;
    public List<float> PriceHistory { get; set; }= new List<float>();

    public static MineObjectTrader Instance { get; set; }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    virtual protected void Start()
    {
        PriceHistory.Add(USDParity);
        

    }
}
