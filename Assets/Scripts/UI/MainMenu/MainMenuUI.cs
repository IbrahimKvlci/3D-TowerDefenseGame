using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button resetProgressBtn;
    [SerializeField] private TextMeshProUGUI playTxt;
    [SerializeField] private TextMeshProUGUI resetProgressTxt;

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
        GameLanguageController.OnLanguageChanged += GameLanguageController_OnLanguageChanged;

        IdleTutorial.Step = 1;
        playTxt.text = GameLanguageController.PlayText;
        resetProgressTxt.text=GameLanguageController.ResetProgressText;
    }

    private void GameLanguageController_OnLanguageChanged(object sender, System.EventArgs e)
    {
        playTxt.text = GameLanguageController.PlayText;
        resetProgressTxt.text = GameLanguageController.ResetProgressText;
    }
}
