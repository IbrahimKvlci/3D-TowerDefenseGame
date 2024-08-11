using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLanguageController
{
    public static event EventHandler OnLanguageChanged;

    public enum LanguagesEnum
    {
        Russian,
        English,
    }

    private static LanguagesEnum _language;
    public static LanguagesEnum Language
    {

        get { return _language; }
        set { _language = value; OnLanguageChanged?.Invoke(typeof(GameLanguageController), EventArgs.Empty); }
    }

    public static string PlayText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Играть";
                    break;
                case LanguagesEnum.English:
                    return "Play";
                    break;
                default:
                    return "Play";
                    break;
            }
        }
    }
    public static string ResetProgressText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "СброситьПрогресс";
                    break;
                case LanguagesEnum.English:
                    return "ResetProgress";
                    break;
                default:
                    return "ResetProgress";
                    break;
            }
        }
    }
    public static string WorldText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Мир";
                    break;
                case LanguagesEnum.English:
                    return "World";
                    break;
                default:
                    return "World";
                    break;
            }
        }
    }
    public static string StartText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Старт";
                    break;
                case LanguagesEnum.English:
                    return "Start";
                    break;
                default:
                    return "Start";
                    break;
            }
        }
    }
    public static string MainMenuText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "ГлавноеМеню";
                    break;
                case LanguagesEnum.English:
                    return "MainMenu";
                    break;
                default:
                    return "MainMenu";
                    break;
            }
        }
    }
    public static string EnterCountText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Ввести Количество";
                    break;
                case LanguagesEnum.English:
                    return "EnterCount";
                    break;
                default:
                    return "EnterCount";
                    break;
            }
        }
    }
    public static string SellText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Продать";
                    break;
                case LanguagesEnum.English:
                    return "Sell";
                    break;
                default:
                    return "Sell";
                    break;
            }
        }
    }
    public static string DayText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "День";
                    break;
                case LanguagesEnum.English:
                    return "Day";
                    break;
                default:
                    return "Day";
                    break;
            }
        }
    }
    public static string UpgradeText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Улучшение";
                    break;
                case LanguagesEnum.English:
                    return "Upgrade";
                    break;
                default:
                    return "Upgrade";
                    break;
            }
        }
    }
    public static string MiningSpeedText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "СкоростьДобычи";
                    break;
                case LanguagesEnum.English:
                    return "MiningSpeed";
                    break;
                default:
                    return "MiningSpeed";
                    break;
            }
        }
    }
    public static string DamageText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Урон";
                    break;
                case LanguagesEnum.English:
                    return "Damage";
                    break;
                default:
                    return "Damage";
                    break;
            }
        }
    }
    public static string MineScannerSpeedText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "СкоростьСканера";
                    break;
                case LanguagesEnum.English:
                    return "MineScannerSpeed";
                    break;
                default:
                    return "MineScannerSpeed";
                    break;
            }
        }
    }
    public static string PlacingSpeedText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "СкоростьУстановки";
                    break;
                case LanguagesEnum.English:
                    return "PlacingSpeed";
                    break;
                default:
                    return "PlacingSpeed";
                    break;
            }
        }
    }
    public static string LevelText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Уровень";
                    break;
                case LanguagesEnum.English:
                    return "Level";
                    break;
                default:
                    return "Level";
                    break;
            }
        }
    }
    public static string TradeText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Торговля";
                    break;
                case LanguagesEnum.English:
                    return "Trade";
                    break;
                default:
                    return "Trade";
                    break;
            }
        }
    }
    public static string PauseText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Пауза";
                    break;
                case LanguagesEnum.English:
                    return "Pause";
                    break;
                default:
                    return "Pause";
                    break;
            }
        }
    }
    public static string RemainingHoursText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "ОставшиесяЧасы";
                    break;
                case LanguagesEnum.English:
                    return "RemainingHours";
                    break;
                default:
                    return "RemainingHours";
                    break;
            }
        }
    }
    public static string CollectedText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Собранное";
                    break;
                case LanguagesEnum.English:
                    return "Collected";
                    break;
                default:
                    return "Collected";
                    break;
            }
        }
    }
    public static string CostText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Стоимость";
                    break;
                case LanguagesEnum.English:
                    return "Cost";
                    break;
                default:
                    return "Cost";
                    break;
            }
        }
    }
    public static string FinishTheDayText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "ЗавершитьДень";
                    break;
                case LanguagesEnum.English:
                    return "FinishTheDay";
                    break;
                default:
                    return "FinishTheDay";
                    break;
            }
        }
    }
    public static string ResultsText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Результаты";
                    break;
                case LanguagesEnum.English:
                    return "Results";
                    break;
                default:
                    return "Results";
                    break;
            }
        }
    }
    public static string HomeText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Главная";
                    break;
                case LanguagesEnum.English:
                    return "Home";
                    break;
                default:
                    return "Home";
                    break;
            }
        }
    }
    public static string HoursText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Часы";
                    break;
                case LanguagesEnum.English:
                    return "Hours";
                    break;
                default:
                    return "Hours";
                    break;
            }
        }
    }
    public static string MaxText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Макс";
                    break;
                case LanguagesEnum.English:
                    return "Max";
                    break;
                default:
                    return "Max";
                    break;
            }
        }
    }
    public static string NameText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "игрок";
                    break;
                case LanguagesEnum.English:
                    return "Player";
                    break;
                default:
                    return "Player";
                    break;
            }
        }
    }
    public static string SpeedUpText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Нажмите 'X', чтобы ускориться";
                    break;
                case LanguagesEnum.English:
                    return "Press \"X\" to speed up";
                    break;
                default:
                    return "Press \"X\" to speed up";
                    break;
            }
        }
    }
    public static string LoadingText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "ЗАГРУЗКА...";
                    break;
                case LanguagesEnum.English:
                    return "LOADING...";
                    break;
                default:
                    return "LOADING...";
                    break;
            }
        }
    }
    public static string FinishedTutorialText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "Вы завершили обучение";
                    break;
                case LanguagesEnum.English:
                    return "You finished the tutorial";
                    break;
                default:
                    return "You finished the tutorial";
                    break;
            }
        }
    }
    public static string ExitTutorialText
    {
        get
        {
            switch (Language)
            {
                case LanguagesEnum.Russian:
                    return "ВЫХОД ИЗ ОБУЧЕНИЯ";
                    break;
                case LanguagesEnum.English:
                    return "EXIT FROM TUTORIAL";
                    break;
                default:
                    return "EXIT FROM TUTORIAL";
                    break;
            }
        }
    }
}
