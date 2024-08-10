using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private Player player;

    [SerializeField] private Transform upgradeTemplate;
    [SerializeField] private Transform container;

    [SerializeField] private TextMeshProUGUI upgradeTxt;

    private void Awake()
    {
        player = Player.Instance;
    }

    private void Start()
    {
        upgradeTemplate.gameObject.SetActive(false);
        upgradePanel.SetActive(false);

        upgradeTxt.text=GameLanguageController.UpgradeText;
    }

    public void OpenUpgradePanelUI()
    {
        upgradePanel.SetActive(true);
        UpdateVisual();
        UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.openPanelound);
    }

    public void CloseUpgradePanelUI()
    {
        upgradePanel.SetActive(false);
        UIAudioEffectController.Instance.PlayAudio(UIAudioEffectController.Instance.UISoundEffectsSO.closePanelSound);

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
