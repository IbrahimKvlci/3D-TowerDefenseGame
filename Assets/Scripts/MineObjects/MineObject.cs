using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObject : MonoBehaviour
{
    [field:SerializeField] public MineObjectSO MineObjectSO { get; set; }
    public int Count { get; set; }
}
