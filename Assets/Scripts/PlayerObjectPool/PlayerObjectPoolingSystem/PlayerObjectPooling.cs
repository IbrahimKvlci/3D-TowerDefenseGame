using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObjectPooling:MonoBehaviour
{
    public List<PlayerObject> PlayerObjectList { get; set; }

    public IPlayerObjectPoolingService PlayerObjectPoolingService { get;private set; }

    public static PlayerObjectPooling Instance { get; set; }

    public void Awake()
    {
        Instance = this;

        PlayerObjectList = new List<PlayerObject>();

        PlayerObjectPoolingService=new PlayerObjectPoolingManager();
    }
}
