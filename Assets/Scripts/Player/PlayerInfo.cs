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
            return BasicIoC.Instance.PlayerDataService.GetPlayerName();
        }
    }
     public Sprite Avatar
    {
        get
        {
            if(BasicIoC.Instance.PlayerDataService.GetPlayerAvatar()!=null)
                return BasicIoC.Instance.PlayerDataService.GetPlayerAvatar();
            return defaultAvatar;
        }
    }
}
