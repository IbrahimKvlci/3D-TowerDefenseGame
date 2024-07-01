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

    private IGameControllerService _gameControllerService;

    private void Awake()
    {
        _gameControllerService=InGameIoC.Instance.GameControllerService;

        pauseBtn.onClick.AddListener(() =>
        {
            Show();
        });
        closeBtn.onClick.AddListener(() =>
        {
            Hide();
        });
        finishTheDayBtn.onClick.AddListener(() =>
        {
            _gameControllerService.FinishTheGame(GameController.Instance, Planet.Instace.PlanetSO.mineObject, Player.Instance);
            Hide();
        });
    }

    private void Start()
    {
        Hide();
    }

    private void UpdateVisual()
    {
        remainingHoursTxt.text = $"{(int)(GameController.Instance.MaxHour - GameController.Instance.Hour)} Hours";
        collectedMineObjectTitleTxt.text = $"Collected {Planet.Instace.PlanetSO.mineObject.MineObjectSO.title}";
        collectedMineObjectValueTxt.text = $"{Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).CurrentCollectedCount}";
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
