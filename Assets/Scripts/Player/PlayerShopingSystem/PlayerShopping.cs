using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShopping : MonoBehaviour
{
    [field:SerializeField] public List<MineObject> MineObjects { get; set; }
    public int Cash { get; set; } = 100;

    public MineObject GetMineObjectFromListByType<T>()
    {
        return MineObjects.FirstOrDefault(obj => obj.GetType() == typeof(T));
    }
}
