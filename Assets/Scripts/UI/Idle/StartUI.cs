using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUI : MonoBehaviour
{
    [SerializeField] private GameObject StartPanel;

    private void Start()
    {
        StartPanel.SetActive(false);
    }

    public void OpenStartPanelUI()
    {
        StartPanel.SetActive(true);
    }

    public void CloseStartPanelUI()
    {
        StartPanel.SetActive(false);
    }
}
