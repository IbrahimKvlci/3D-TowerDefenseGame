using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILanguageService
{
    GameLanguageController.LanguagesEnum GetLanguage();
    void SetLanguage(GameLanguageController.LanguagesEnum language);
}
