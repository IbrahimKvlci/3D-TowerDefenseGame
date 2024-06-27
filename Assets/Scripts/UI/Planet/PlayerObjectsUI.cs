using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectsUI : MonoBehaviour
{
    [SerializeField] private List<PlayerObjectProduct> playerObjectList;
    [SerializeField] private Transform playerObjectTemplate;
    [SerializeField] private Transform container;

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
            Transform playerObjectTransform = Instantiate(playerObjectTemplate, container);
            playerObjectTransform.gameObject.SetActive(true);
            playerObjectTransform.GetComponent<PlayerObjectSingleUI>().SetPlayerObjectUI(playerObject);
        }
    }
}
