using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI collectedTitleText;
    [SerializeField] private TextMeshProUGUI collectedValueText;
    [SerializeField] private Button homeBtn;

    [SerializeField] private TextMeshProUGUI resultsTxt;
    [SerializeField] private TextMeshProUGUI costTxt;
    [SerializeField] private TextMeshProUGUI homeTxt;


    private IGameControllerService _gameControllerService;

    private void Awake()
    {
        homeBtn.onClick.AddListener(() =>
        {
            if (Player.Instance.PlayerFirstPlay)
            {
                IdleTutorial.Step = 3;
                SceneLoader.LoadScene(SceneLoader.Scene.IdleTutorial);
            }
            else
                SceneLoader.LoadScene(SceneLoader.Scene.Idle);
            YandexGame.FullscreenShow();
        });

        _gameControllerService = InGameIoC.Instance.GameControllerService;
    }

    void Start()
    {
        _gameControllerService.OnGameOver += gameControllerService_OnGameOver;
        Hide();

        resultsTxt.text = GameLanguageController.ResultsText;
        costTxt.text = GameLanguageController.CostText;
        homeTxt.text=GameLanguageController.HomeText;
    }

    private void gameControllerService_OnGameOver(object sender, System.EventArgs e)
    {
        Show();
    }

    public void Show()
    {
        gameObject.SetActive(true);
        UpdateVisual();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void UpdateVisual()
    {
        costText.text = $"${Player.Instance.PlayerShopping.Cost}";

        switch (GameLanguageController.Language)
        {
            case GameLanguageController.LanguagesEnum.Russian:
                collectedTitleText.text = $"{GameLanguageController.CollectedText} {Planet.Instace.PlanetSO.mineObject.MineObjectSO.titleRU}";
                break;
            case GameLanguageController.LanguagesEnum.English:
                collectedTitleText.text = $"{GameLanguageController.CollectedText} {Planet.Instace.PlanetSO.mineObject.MineObjectSO.titleEN}";
                break;
            default:
                break;
        }

        collectedValueText.text=$"{(Math.Truncate(Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).CurrentCollectedCount * 100) / 100)}";
    }

}
