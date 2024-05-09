using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Planet : MonoBehaviour
{
    [field: SerializeField] public PlanetSO PlanetSO {  get; set; }
}
