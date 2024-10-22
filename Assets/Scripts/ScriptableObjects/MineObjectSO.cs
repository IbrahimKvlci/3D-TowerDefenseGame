using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MineObjectSO : ScriptableObject
{
    public int id;
    public Transform prefab;
    public Sprite icon;
    public string titleEN;
    public string titleRU;
    public float startingPrice;
}
