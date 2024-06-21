using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private GameObject UpgradePanel;

    private void Start()
    {
        UpgradePanel.SetActive(false);
    }

    public void OpenUpgradePanelUI()
    {
        UpgradePanel.SetActive(true);
    }

    public void CloseUpgradePanelUI()
    {
        UpgradePanel.SetActive(false);
    }
}
