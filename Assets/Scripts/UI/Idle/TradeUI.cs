using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TradeUI : MonoBehaviour
{
    public MineObjectTrader CurrentMineObjectTrader { get; set; }
    [field:SerializeField] public List<MineObjectTrader> MineObjectTraderList {  get; set; }

    [SerializeField] private GameObject TradePanel;
    [SerializeField] private Image currentMineObjectIcon;
    [SerializeField] private TMP_InputField countInputField;
    [SerializeField] private Button sellBtn;
    [SerializeField] private MineObjectsUI mineObjectsUI;

    private ITradingMineObjectService _tradingMineObjectService;

    private void Awake()
    {
        _tradingMineObjectService = TradingIoC.Instance.TradingMineObjectService;

        sellBtn.onClick.AddListener(() =>
        {
            SellMineObject(Player.Instance, CurrentMineObjectTrader.MineObject);
        });
    }

    private void Start()
    {
        CurrentMineObjectTrader = MineObjectTraderList[0];
        ChangeCurrentMineObjectIcon(CurrentMineObjectTrader.MineObject.MineObjectSO.icon);
        TradePanel.SetActive(false);
    }

    public void OpenTradePanelUI()
    {
        TradePanel.SetActive(true);
    }

    public void CloseTradePanelUI()
    {
        TradePanel.SetActive(false);
    }

    public void ChangeCurrentMineObjectIcon(Sprite sprite)
    {
        currentMineObjectIcon.sprite= sprite;
    }

    private void SellMineObject(Player player,MineObject mineObject)
    {
        int sellingCount = Int32.Parse(countInputField.text);

        _tradingMineObjectService.SellMineObject(CurrentMineObjectTrader,mineObject, player, sellingCount);

        mineObjectsUI.UpdateVisual();
    }
}
