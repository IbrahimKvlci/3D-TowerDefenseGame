using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class RewardedAds : MonoBehaviour
{
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    void Rewarded(int id)
    {
        switch (id)
        {
            case 0:
                Player.Instance.PlayerShopping.Cash += 500;
                break;
            default:
                break;
        }
    }
}
