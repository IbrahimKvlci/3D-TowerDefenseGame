using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MineObjectSingleUI : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI countText;
    private MineObject mineObject;

    public void SetMineObjectUI(MineObject mineObject)
    {
        mineObject.OnMineObjectCountChanged += MineObject_OnMineObjectCountChanged;
        this.mineObject = mineObject;

        icon.sprite=mineObject.MineObjectSO.icon;
        countText.text = (Math.Truncate(mineObject.Count * 100) / 100).ToString();
    }

    private void MineObject_OnMineObjectCountChanged(object sender, System.EventArgs e)
    {
        countText.text = (Math.Truncate(mineObject.Count*100)/100).ToString();
    }
}
