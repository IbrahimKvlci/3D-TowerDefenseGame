using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        SceneLoader.LoadScene(SceneLoader.Scene.Idle);
    }
}
