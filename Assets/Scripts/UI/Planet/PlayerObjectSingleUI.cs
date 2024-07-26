using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerObjectSingleUI : MonoBehaviour
{
    public PlayerObjectProduct PlayerObject { get; set; }

    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button playerObjectProductBtn;


    private IShoppingInGameService _shoppingInGameService;


    private void Awake()
    {
        _shoppingInGameService = InGameIoC.Instance.ShoppingInGameService;

        playerObjectProductBtn.onClick.AddListener(() =>
        {
            _shoppingInGameService.GivePlayerObjectProductToPlayer(Player.Instance, PlayerObject);
            UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.openPanelound);

        });
    }

    public void SetPlayerObjectUI(PlayerObjectProduct playerObject)
    {
        PlayerObject = playerObject;

        icon.sprite = playerObject.PlayerObjectSO.icon;
        priceText.text = $"${((PlayerObjectProductSO)playerObject.PlayerObjectSO).Price}";
    }

}
