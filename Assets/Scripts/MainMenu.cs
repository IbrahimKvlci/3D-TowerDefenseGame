using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        GameLanguageController.Language = MainMenuIoC.Instance._languageService.GetLanguage();

    }

    private void Start()
    {
        BasicIoC.Instance.GameReadyService.GameReady();
    }
}
