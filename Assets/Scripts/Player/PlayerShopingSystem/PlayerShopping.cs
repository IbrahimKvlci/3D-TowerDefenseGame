using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShopping : MonoBehaviour
{
    [field:SerializeField] public List<MineObject> MineObjects { get; set; }
    public int Cash { get; set; }
}
