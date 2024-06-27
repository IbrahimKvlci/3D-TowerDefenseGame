using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradingIoC : MonoBehaviour
{
    public ITradingMineObjectService TradingMineObjectService {  get; set; }

    public static TradingIoC Instance { get; set; }

    private void Awake()
    {
        Instance = this;

        TradingMineObjectService=new TradingMineObjectManager();
    }
}
