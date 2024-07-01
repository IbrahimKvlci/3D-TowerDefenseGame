using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartUI : MonoBehaviour
{
    [field:SerializeField] public List<Planet> PlanetList { get; set; }

    [SerializeField] private GameObject StartPanel;
    [SerializeField] private TextMeshProUGUI planetNameText;
    [SerializeField] private Image planetImage;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button rightBtn, leftBtn;
    [SerializeField] private Button startBtn;

    public Planet CurrentPlanet { get; set; }

    private IShoppingPlanetService _shoppingPlanetService;

    

    private void Awake()
    {
        _shoppingPlanetService = PlanetIoC.Instance.ShoppingPlanetService;

        rightBtn.onClick.AddListener(() =>
        {
            ChangePage(true);
        });
        leftBtn.onClick.AddListener(() => 
        { 
            ChangePage(false); 
        });

        startBtn.onClick.AddListener(() =>
        {
            _shoppingPlanetService.PayToTravelThePlanet(Player.Instance, CurrentPlanet);
            GameManager.Instance.NextDay();
        });
    }

    private void Start()
    {
        StartPanel.SetActive(false);
        SetPlanetUI(PlanetList[0]);
    }

    public void OpenStartPanelUI()
    {
        StartPanel.SetActive(true);
    }

    public void CloseStartPanelUI()
    {
        StartPanel.SetActive(false);
    }

    private void SetPlanetUI(Planet planet)
    {
        CurrentPlanet=planet;

        planetNameText.text = planet.PlanetSO.title;
        planetImage.sprite = planet.PlanetSO.icon;
        priceText.text = planet.PlanetSO.price.ToString();
    }

    private void ChangePage(bool goRight)
    {
        int newIndex;

        if (goRight)
        {
            newIndex = PlanetList.IndexOf(CurrentPlanet) + 1;

            if (newIndex >= PlanetList.Count)
            {
                newIndex = 0;
            }
        }
        else
        {
            newIndex = PlanetList.IndexOf(CurrentPlanet) - 1;

            if (newIndex < 0)
            {
                newIndex = PlanetList.Count - 1;
            }
        }

        SetPlanetUI(PlanetList[newIndex]);

    }
}
