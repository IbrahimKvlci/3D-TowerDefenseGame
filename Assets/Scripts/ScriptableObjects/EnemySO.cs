using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class EnemySO : ScriptableObject
{
    public Transform prefab;
    public Sprite icon;
    public float speed;
    public float maxHealth;
}
