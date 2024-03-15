using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlacement : MonoBehaviour
{
    public Grid Grid { get; set; }

    private void Awake()
    {
        Grid = GetComponent<Grid>();
    }
}
