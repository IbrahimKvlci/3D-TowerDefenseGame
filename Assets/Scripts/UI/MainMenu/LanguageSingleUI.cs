using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LanguageSingleUI : MonoBehaviour
{
    [field:SerializeField] public GameLanguageController.LanguagesEnum LanguageEnum {  get; set; }
    [SerializeField] private GameObject selectedIcon;
    [SerializeField] private LanguageUI languageUI;

    private void Start()
    {
        YandexGame.LanguageRequest();

        switch (YandexGame.lang)
        {
            case "ru":
                if (LanguageEnum == GameLanguageController.LanguagesEnum.Russian)
                    SetLanguage();
                break;
            case "en":
                if(LanguageEnum== GameLanguageController.LanguagesEnum.English)
                    SetLanguage(); 
                break;
            default:
                break;
        }
    }

    public void SetLanguage()
    {
        GameLanguageController.Language=LanguageEnum;
        MainMenuIoC.Instance._languageService.SetLanguage(LanguageEnum);
        languageUI.SetAllVisualsDisabledInsteadOfCurrentLanguage();
    }

    public void SetVisualSelected()
    {
        selectedIcon.gameObject.SetActive(true);
    }
    public void SetVisualDisabled()
    {
        selectedIcon.gameObject.SetActive(false);

    }
}

