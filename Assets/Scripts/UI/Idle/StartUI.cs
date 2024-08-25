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
    [SerializeField] private GameObject planetObject;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button rightBtn, leftBtn;
    [SerializeField] private Button startBtn;

    [SerializeField] private TextMeshProUGUI startTxt;
    [SerializeField] private TextMeshProUGUI startPanelTxt;

    public Planet CurrentPlanet { get; set; }

    private IShoppingPlanetService _shoppingPlanetService;

    

    private void Awake()
    {
        _shoppingPlanetService = PlanetIoC.Instance.ShoppingPlanetService;

        rightBtn.onClick.AddListener(() =>
        {
            ChangePage(true);
            UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.openPanelound);
        });
        leftBtn.onClick.AddListener(() => 
        { 
            ChangePage(false);
            UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.openPanelound);
        });

        startBtn.onClick.AddListener(() =>
        {
            _shoppingPlanetService.PayToTravelThePlanet(Player.Instance, CurrentPlanet);
        });
    }

    private void Start()
    {
        StartPanel.SetActive(false);
        SetPlanetUI(PlanetList[0]);

        startTxt.text = GameLanguageController.StartText;
        startPanelTxt.text = GameLanguageController.StartText;
    }

    public void OpenStartPanelUI()
    {
        StartPanel.SetActive(true);
        UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.openPanelound);

    }

    public void CloseStartPanelUI()
    {
        StartPanel.SetActive(false);
        UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.closePanelSound);

    }

    private void SetPlanetUI(Planet planet)
    {
        CurrentPlanet=planet;

        switch (GameLanguageController.Language)
        {
            case GameLanguageController.LanguagesEnum.Russian:
                planetNameText.text = planet.PlanetSO.titleRU;
                break;
            case GameLanguageController.LanguagesEnum.English:
                planetNameText.text = planet.PlanetSO.titleEN;
                break;
            default:
                break;
        }
        
        planetObject.GetComponent<Renderer>().material = planet.PlanetSO.planetMaterial;
        priceText.text = $"${planet.PlanetSO.price.ToString()}";
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
