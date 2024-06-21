using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private Player player;

    [SerializeField] private Transform upgradeTemplate;
    [SerializeField] private Transform container;

    private void Start()
    {
        upgradePanel.SetActive(false);
    }

    public void OpenUpgradePanelUI()
    {
        upgradePanel.SetActive(true);

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
            //playerUpgradeTransform.GetComponent<DeliveryManagerSingleUI>().SetRecipeSO(recipeSO);
        }
    }
}
