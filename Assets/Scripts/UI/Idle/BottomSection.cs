using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BottomSection : MonoBehaviour
{
    [SerializeField] private Button mainMenuBtn;
    [SerializeField] private TextMeshProUGUI mainMenuTxt;

    private void Awake()
    {
        mainMenuBtn.onClick.AddListener(() =>
        {
            SceneLoader.LoadScene(SceneLoader.Scene.MainMenu);
        });
    }

    private void Start()
    {
        mainMenuTxt.text = GameLanguageController.MainMenuText;
    }
}
