using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button resetProgressBtn;

    private void Awake()
    {
        playBtn.onClick.AddListener(() =>
        {
            if (Player.Instance.PlayerFirstPlay)
            {
                SceneLoader.LoadScene(SceneLoader.Scene.IdleTutorial);
            }
            else
            {
                SceneLoader.LoadScene(SceneLoader.Scene.Idle);

            }
        });
        resetProgressBtn.onClick.AddListener(() =>
        {
            PlayerPrefsController.Instance.ResetProgress();
        });
    }

    private void Start()
    {
        IdleTutorial.Step = 1;
    }
}
