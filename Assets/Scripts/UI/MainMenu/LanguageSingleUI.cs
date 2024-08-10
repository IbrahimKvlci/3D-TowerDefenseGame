using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSingleUI : MonoBehaviour
{
    [field:SerializeField] public GameLanguageController.LanguagesEnum LanguageEnum {  get; set; }
    [SerializeField] private GameObject selectedIcon;
    [SerializeField] private LanguageUI languageUI;

    public void SetLanguage()
    {
        GameLanguageController.Language=LanguageEnum;
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

