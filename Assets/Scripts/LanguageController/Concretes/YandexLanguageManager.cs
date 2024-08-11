using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class YandexLanguageManager : ILanguageService
{
    public GameLanguageController.LanguagesEnum GetLanguage()
    {
        switch (YandexGame.lang)
        {
            case "ru":
                return GameLanguageController.LanguagesEnum.Russian;
            case "en":
                return GameLanguageController.LanguagesEnum.English;
            default:
                return GameLanguageController.LanguagesEnum.English;
        }
    }

    public void SetLanguage(GameLanguageController.LanguagesEnum language)
    {
        switch (language)
        {
            case GameLanguageController.LanguagesEnum.Russian:
                YandexGame.SwitchLanguage("ru");
                break;
            case GameLanguageController.LanguagesEnum.English:
                YandexGame.SwitchLanguage("en");
                break;
            default:
                break;
        }
    }
}
