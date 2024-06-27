using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PlayerObjectSingleUI : MonoBehaviour
{
    public PlayerObjectProduct PlayerObject { get; set; }

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button playerObjectProductBtn;


    private IShoppingInGameService _shoppingInGameService;

    [Inject]
    public void Construct(IShoppingInGameService shoppingInGameService)
    {
        _shoppingInGameService = shoppingInGameService;
    }

    private void Awake()
    {
        playerObjectProductBtn.onClick.AddListener(() =>
        {
            _shoppingInGameService.GivePlayerObjectProductToPlayer(Player.Instance, PlayerObject);
        });
    }

    public void SetPlayerObjectUI(PlayerObjectProduct playerObject)
    {
        PlayerObject = playerObject;

        icon.sprite = playerObject.PlayerObjectSO.icon;
        priceText.text = $"${((PlayerObjectProductSO)playerObject.PlayerObjectSO).Price}";
    }

    public class Factory : PlaceholderFactory<PlayerObjectSingleUI> { }
}
