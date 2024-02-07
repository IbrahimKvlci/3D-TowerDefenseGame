using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class MineObjectSO : ScriptableObject
{
    public Transform prefab;
    public Sprite icon;
    public float miningTimerMax;
    public string title;
}