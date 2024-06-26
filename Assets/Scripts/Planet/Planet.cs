using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Planet : MonoBehaviour
{
    [field: SerializeField] public PlanetSO PlanetSO {  get; set; }

    public static Planet Instace { get; set; }

    private void Awake()
    {
        if (Instace != null)
        {
            Destroy(gameObject);
        }

        Instace = this;
    }
}
