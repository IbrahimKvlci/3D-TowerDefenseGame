using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObjectTraderContainer : MonoBehaviour
{
    [field:SerializeField] public List<MineObjectTrader> MineObjectTraderList { get; set; }

    public static MineObjectTraderContainer Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);
    }
}
