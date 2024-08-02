using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public enum Scene
    {
        IdleTutorial,
        TutorialPlanetScene,
        MainMenu,
        LoadingScene,
        Idle,
        HorrorPlanetScene,
        ZombiePlanetScene,
        AnimalPlanetScene,
        DragonPlanetScene,
    }

    private static Scene targetScene;

    public static void LoadScene(Scene scene)
    {
        SceneLoader.targetScene = scene;

        SceneManager.LoadScene(Scene.LoadingScene.ToString());
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene.ToString());
    }
}
