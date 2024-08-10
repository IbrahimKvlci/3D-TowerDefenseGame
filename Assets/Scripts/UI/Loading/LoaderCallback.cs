using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI loadingText;

    private bool isFiestUpdate = true;

    private void Start()
    {
        loadingText.text = GameLanguageController.LoadingText;
    }

    private void Update()
    {
        if (isFiestUpdate)
        {
            isFiestUpdate = false;

            SceneLoader.LoaderCallback();
        }
    }
}
