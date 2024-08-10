using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageUI : MonoBehaviour
{
    [SerializeField] private List<LanguageSingleUI> languageSingleUIList;

    private void Start()
    {
        foreach (var item in languageSingleUIList)
        {
            if (item.LanguageEnum==GameLanguageController.Language)
            {
                item.SetVisualSelected();
                continue;
            }
            item.SetVisualDisabled();
        }
    }

    public void SetAllVisualsDisabledInsteadOfCurrentLanguage()
    {
        foreach (var item in languageSingleUIList)
        {
            if (item.LanguageEnum == GameLanguageController.Language)
            {
                item.SetVisualSelected();
                continue;
            }
            item.SetVisualDisabled();
        }
    }
}
