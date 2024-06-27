using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private Player player;

    [SerializeField] private Transform upgradeTemplate;
    [SerializeField] private Transform container;


    private void Start()
    {
        upgradeTemplate.gameObject.SetActive(false);
        upgradePanel.SetActive(false);
    }

    public void OpenUpgradePanelUI()
    {
        upgradePanel.SetActive(true);
        UpdateVisual();
    }

    public void CloseUpgradePanelUI()
    {
        upgradePanel.SetActive(false);
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == upgradeTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (PlayerUpgradeSO playerUpgradeSO in player.PlayerUpgrading.PlayerUpgradeSOList)
        {
            Transform playerUpgradeTransform = Instantiate(upgradeTemplate, container);
            playerUpgradeTransform.gameObject.SetActive(true);
            playerUpgradeTransform.GetComponent<UpgradeSingleUI>().SetUpgrade(playerUpgradeSO, player);
        }
    }

    
}
