using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridPlacement : MonoBehaviour
{
    public Grid Grid { get; set; }

    public static GridPlacement Instance { get; set; }


    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(Instance.gameObject);
        }

        Instance = this;

        Grid = GetComponent<Grid>();

    }


}
