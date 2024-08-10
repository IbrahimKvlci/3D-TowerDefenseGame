using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo:MonoBehaviour
{
    public string Name
    {
        get
        {
            return GameLanguageController.NameText;
        }
    }
    [field:SerializeField] public Sprite Avatar { get; set; }
}
