using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HourUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hourText;

    private void Start()
    {
        GameController.Instance.OnHourChanged += Instance_OnHourChanged;

        UpdateHourText();
    }

    private void Instance_OnHourChanged(object sender, System.EventArgs e)
    {
        UpdateHourText();
    }

    private void UpdateHourText()
    {
        hourText.text = $"{Convert.ToInt32(GameController.Instance.Hour)} {GameLanguageController.HoursText}";
    }
}
