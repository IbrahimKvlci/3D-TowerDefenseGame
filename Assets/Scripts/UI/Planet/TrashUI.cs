using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TrashUI : MonoBehaviour
{
    [SerializeField] private Button trashBtn;

    private IObjectPlacementService _objectPlacementService;

    private void Awake()
    {
        _objectPlacementService = InGameIoC.Instance.ObjectPlacementService;

        trashBtn.onClick.AddListener(() =>
        {
            _objectPlacementService.ClearObjectToPlaceBase(Player.Instance);
            Hide();
        });
    }

    private void Start()
    {
        Hide();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void OnPointerEnter()
    {
        if (_objectPlacementService.HasPlayerPlayerObjectToPlace(Player.Instance))
        {
            Show();
        }
    }

    public void OnPointerExit()
    {
        Hide();
    }
}
