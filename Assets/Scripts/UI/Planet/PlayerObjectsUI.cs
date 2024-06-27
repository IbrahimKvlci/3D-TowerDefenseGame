using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerObjectsUI : MonoBehaviour
{
    [SerializeField] private List<PlayerObjectProduct> playerObjectList;
    [SerializeField] private Transform playerObjectTemplate;
    [SerializeField] private Transform container;

    [Inject] private PlayerObjectSingleUI.Factory _playerObjectSingleUIFactory;

    private void Start()
    {
        playerObjectTemplate.gameObject.SetActive(false);
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            if (child == playerObjectTemplate) continue;
            Destroy(child.gameObject);
        }

        foreach (PlayerObjectProduct playerObject in playerObjectList)
        {
            PlayerObjectSingleUI playerObjectTransform = _playerObjectSingleUIFactory.Create();
            playerObjectTransform.transform.SetParent(container, false);
            playerObjectTransform.gameObject.SetActive(true);
            playerObjectTransform.GetComponent<PlayerObjectSingleUI>().SetPlayerObjectUI(playerObject);
        }
    }
}
