using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomSection : MonoBehaviour
{
    [SerializeField] private Button mainMenuBtn;

    private void Awake()
    {
        mainMenuBtn.onClick.AddListener(() =>
        {
            SceneLoader.LoadScene(SceneLoader.Scene.MainMenu);
        });
    }
}
