using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuIoC : MonoBehaviour
{
    public static MainMenuIoC Instance { get; set; }

    public ILanguageService _languageService { get; set; }

    private void Awake()
    {
        Instance = this;

        _languageService = new YandexLanguageManager();
    }
}
