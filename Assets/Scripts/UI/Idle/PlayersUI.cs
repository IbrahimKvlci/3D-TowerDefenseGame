using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersUI : MonoBehaviour
{
    [SerializeField] private List<Player> playerList;
    [SerializeField] private Transform playerContainer;
    [SerializeField] private Transform playerTemplate;

    private void Awake()
    {
        playerList = new List<Player> { Player.Instance};
    }
    private void Start()
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach (Transform item in playerContainer)
        {
            if (item == playerTemplate) continue;
            Destroy(item.gameObject);
        }

        foreach (Player player in playerList)
        {
            Transform playerTransform=Instantiate(playerTemplate, playerContainer);
            playerTransform.gameObject.SetActive(true);
            playerTransform.GetComponent<PlayerSingleUI>().SetPlayerUI(player);
        }
    }
}
