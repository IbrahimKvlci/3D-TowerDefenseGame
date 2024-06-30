using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerShopping : MonoBehaviour
{
    public event EventHandler OnCashChanged;

    [field:SerializeField] public List<MineObject> MineObjects { get; set; }

    public int Cost { get; set; }

    private int cash = 100;
    public int Cash
    {
        get { return cash; }
        set { cash = value; OnCashChanged?.Invoke(this, EventArgs.Empty); }
    }

    public MineObject GetMineObjectFromListByType<T>()
    {
        return MineObjects.FirstOrDefault(obj => obj.GetType() == typeof(T));
    }

    public MineObject GetMineObjectFromListByObject(MineObject mineObject)
    {
        return MineObjects.FirstOrDefault(obj => obj.GetType() == mineObject.GetType());
    }

    public void PlayerShoppingNewDay()
    {
        foreach (MineObject mineObject in MineObjects)
        {
            InGameIoC.Instance.MineObjectService.ResetMineObjectCurrentCount(mineObject);
        }
        Cost = 0;
    }
}
