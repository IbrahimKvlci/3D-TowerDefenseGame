using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PausePanelUI : MonoBehaviour
{
    [SerializeField] private Button pauseBtn;
    [SerializeField] private Button closeBtn;
    [SerializeField] private Button finishTheDayBtn;

    [SerializeField] private TextMeshProUGUI remainingHoursTxt;
    [SerializeField] private TextMeshProUGUI collectedMineObjectTitleTxt;
    [SerializeField] private TextMeshProUGUI collectedMineObjectValueTxt;
    [SerializeField] private TextMeshProUGUI costTxt;

    [SerializeField] private TextMeshProUGUI pauseTxt;
    [SerializeField] private TextMeshProUGUI costTitleTxt;
    [SerializeField] private TextMeshProUGUI finishTheDayTxt;

    private IGameControllerService _gameControllerService;

    private void Awake()
    {
        _gameControllerService=InGameIoC.Instance.GameControllerService;

        pauseBtn.onClick.AddListener(() =>
        {
            Show();
            UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.openPanelound);

        });
        closeBtn.onClick.AddListener(() =>
        {
            Hide();
            UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.closePanelSound);

        });
        finishTheDayBtn.onClick.AddListener(() =>
        {
            _gameControllerService.FinishTheGame(GameController.Instance, Planet.Instace.PlanetSO.mineObject, Player.Instance);
            Hide();
            UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.openPanelound);

        });
    }

    private void Start()
    {
        Hide();

        pauseTxt.text = GameLanguageController.PauseText;
        costTitleTxt.text = GameLanguageController.CostText;
        finishTheDayTxt.text=GameLanguageController.FinishTheDayText;
    }

    private void UpdateVisual()
    {
        switch (GameLanguageController.Language)
        {
            case GameLanguageController.LanguagesEnum.Russian:
                collectedMineObjectTitleTxt.text = $"{GameLanguageController.CollectedText} {Planet.Instace.PlanetSO.mineObject.MineObjectSO.titleRU}";
                break;
            case GameLanguageController.LanguagesEnum.English:
                collectedMineObjectTitleTxt.text = $"{GameLanguageController.CollectedText} {Planet.Instace.PlanetSO.mineObject.MineObjectSO.titleEN}";
                break;
            default:
                break;
        }
        collectedMineObjectValueTxt.text = $"{(Math.Truncate(Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).CurrentCollectedCount * 100) / 100)}";
        costTxt.text = $"${Player.Instance.PlayerShopping.Cost}";
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _gameControllerService.ResumeTheGame(GameController.Instance);
    }

    public void Show()
    {
        gameObject.SetActive(true);
        _gameControllerService.PauseTheGame(GameController.Instance);
        UpdateVisual();
    }
}
