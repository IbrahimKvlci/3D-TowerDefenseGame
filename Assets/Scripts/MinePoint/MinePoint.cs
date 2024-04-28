using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePoint : MonoBehaviour
{

    [field:SerializeField] public MinePointSO MinePointSO {  get; set; }

    public bool IsScanned { get; set; }
    public float MineCount { get; set; }

    private void Awake()
    {
        IsScanned = false;
        
    }

}
