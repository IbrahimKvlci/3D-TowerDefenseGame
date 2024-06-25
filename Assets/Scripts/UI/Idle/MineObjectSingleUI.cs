using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MineObjectSingleUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI countText;

    public void SetMineObjectUI(MineObject mineObject)
    {
        icon.sprite=mineObject.MineObjectSO.icon;
        countText.text = mineObject.Count.ToString();
    }
}
