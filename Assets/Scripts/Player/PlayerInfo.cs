using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo:MonoBehaviour
{
    [field:SerializeField] public string Name { get; set; }
    [field:SerializeField] public Sprite Avatar { get; set; }
}
