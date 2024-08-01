using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    private bool isFiestUpdate = true;

    private void Update()
    {
        if (isFiestUpdate)
        {
            isFiestUpdate = false;

            SceneLoader.LoaderCallback();
        }
    }
}
