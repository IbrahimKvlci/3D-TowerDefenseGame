using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    public static PlayerPrefsController Instance { get; set; }

    enum PlayerPrefsEnum
    {
        PlayerCash,
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        Player.Instance.PlayerShopping.Cash= GetFloat(PlayerPrefsEnum.PlayerCash);
        Player.Instance.PlayerShopping.OnCashChanged += PlayerShopping_OnCashChanged;
    }

    private void PlayerShopping_OnCashChanged(object sender, System.EventArgs e)
    {
        SetFloat(PlayerPrefsEnum.PlayerCash,Player.Instance.PlayerShopping.Cash);
    }
    private void SetFloat(PlayerPrefsEnum playerPrefsEnum,float value)
    {
        PlayerPrefs.SetFloat(playerPrefsEnum.ToString(), value);
    }

    private float GetFloat(PlayerPrefsEnum playerPrefsEnum)
    {
        return PlayerPrefs.GetFloat(playerPrefsEnum.ToString());
    }
}
