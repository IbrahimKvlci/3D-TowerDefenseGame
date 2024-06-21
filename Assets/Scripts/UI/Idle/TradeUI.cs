using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TradeUI : MonoBehaviour
{
    [SerializeField] private GameObject TradePanel;

    private void Start()
    {
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
}
