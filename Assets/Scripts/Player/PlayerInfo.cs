using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo:MonoBehaviour
{
    [SerializeField] private Sprite defaultAvatar;

    public string Name
    {
        get
        {
            try
            {
                return BasicIoC.Instance.PlayerDataService.GetPlayerName();
            }
            catch (System.Exception)
            {

                return "Player";
            }
            
        }
    }
     public Sprite Avatar
    {
        get
        {
            try
            {
                if (BasicIoC.Instance.PlayerDataService.GetPlayerAvatar() != null)
                    return BasicIoC.Instance.PlayerDataService.GetPlayerAvatar();
                return defaultAvatar;
            }
            catch (System.Exception)
            {

                return defaultAvatar;
            }
            
        }
    }
}
