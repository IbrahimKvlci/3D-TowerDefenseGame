using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineObjectsUI : MonoBehaviour
{
    [SerializeField] private Transform mineObjectTemplate;
    [SerializeField] private Transform mineObjectContainer;

    private void Start()
    {
        mineObjectTemplate.gameObject.SetActive(false);
        UpdateVisual();
    }

    public void UpdateVisual()
    {
        foreach (Transform child in mineObjectContainer)
        {
            if (child == mineObjectTemplate) continue;

            Destroy(child.gameObject);
        }

        foreach (MineObject mineObject in Player.Instance.PlayerShopping.MineObjects)
        {
            Transform mineObjectUI = Instantiate(mineObjectTemplate, mineObjectContainer);
            mineObjectUI.gameObject.SetActive(true);
            mineObjectUI.GetComponent<MineObjectSingleUI>().SetMineObjectUI(mineObject);
        }

        
    }
}
