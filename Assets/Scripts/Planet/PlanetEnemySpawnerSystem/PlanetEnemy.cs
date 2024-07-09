using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlanetEnemy
{
    [field:SerializeField] public Enemy Enemy { get; set; }
    [field:SerializeField] public int CountMultiplier { get; set; }
    [field:SerializeField] public int MaxCountMultiplier { get; set; }

}
