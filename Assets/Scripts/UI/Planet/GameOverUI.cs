using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private TextMeshProUGUI collectedTitleText;
    [SerializeField] private TextMeshProUGUI collectedValueText;
    [SerializeField] private Button homeBtn;


    private IGameControllerService _gameControllerService;

    private void Awake()
    {
        homeBtn.onClick.AddListener(() =>
        {
            SceneLoader.LoadScene(SceneLoader.Scene.Idle);
        });

        _gameControllerService = InGameIoC.Instance.GameControllerService;
    }

    void Start()
    {
        _gameControllerService.OnGameOver += gameControllerService_OnGameOver;
        Hide();
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
        collectedTitleText.text = $"Collected {Planet.Instace.PlanetSO.mineObject.MineObjectSO.title}";
        collectedValueText.text=$"{Player.Instance.PlayerShopping.GetMineObjectFromListByObject(Planet.Instace.PlanetSO.mineObject).CurrentCollectedCount}";
    }

}
