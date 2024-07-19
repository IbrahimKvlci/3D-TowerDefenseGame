using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public enum Scene
    {
        SampleScene,
        Idle,
        HorrorPlanetScene,
        ZombiePlanetScene,
        AnimalPlanetScene,
    }

    public static void LoadScene(Scene scene)
    {
        SceneManager.LoadScene(scene.ToString());
    }
}
