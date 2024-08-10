using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IdleTutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> stepObjectList;

    [SerializeField] private Button startBtn;
    [SerializeField] private Button travelBtn;
    [SerializeField] private Button sellBtn;
    [SerializeField] private Button changePageBtn;
    [SerializeField] private Button tradeBtn;
    [SerializeField] private Button exitTutorialBtn;

    [SerializeField] private TMP_InputField enterNumberField;
    [SerializeField] private TextMeshProUGUI finishedTxt;
    [SerializeField] private TextMeshProUGUI exitTxt;


    public static int Step { get; set; }

    

    private void Awake()
    {
        startBtn.onClick.AddListener(() =>
        {
            if(Step==1)
                NextStep();
        });
        travelBtn.onClick.AddListener(() =>
        {

        });
        sellBtn.onClick.AddListener(() =>
        {
            if(Step==6)
                NextStep();

        });
        changePageBtn.onClick.AddListener(() =>
        {
            if(Step==4)
                NextStep();

        });
        tradeBtn.onClick.AddListener(() =>
        {
            if(Step==3)
                NextStep();

        });
        exitTutorialBtn.onClick.AddListener(() =>
        {
            Player.Instance.PlayerFirstPlay = false;
            PlayerPrefsController.Instance.ResetProgress();
            SceneLoader.LoadScene(SceneLoader.Scene.Idle);
        });
        enterNumberField.onValueChanged.AddListener(delegate{
            if (Step == 5)
            {
                NextStep();
                Debug.Log(Step);
            }
        });

        
    }

    private void Start()
    {
        CloseAllStepObjects();
        RunStep();
        Debug.Log(Step);

        finishedTxt.text = GameLanguageController.FinishedTutorialText;
        exitTxt.text = GameLanguageController.ExitTutorialText;
    }

    private void Update()
    {
        Time.timeScale = 1;
    }

    private void RunStep()
    {
        switch (Step)
        {
            case 1:
                CloseAllStepObjects();
                CloseAllInteractables();
                stepObjectList[0].SetActive(true);
                startBtn.interactable= true;
                break;
            case 2:
                CloseAllStepObjects();
                CloseAllInteractables();
                stepObjectList[1].SetActive(true);
                travelBtn.interactable = true;
                break;
            case 3:
                CloseAllStepObjects();
                CloseAllInteractables();
                stepObjectList[2].SetActive(true);
                tradeBtn.interactable = true;
                break;
            case 4:
                CloseAllStepObjects();
                CloseAllInteractables();
                stepObjectList[3].SetActive(true);
                changePageBtn.interactable = true;
                break;
            case 5:
                CloseAllStepObjects();
                CloseAllInteractables();
                stepObjectList[4].SetActive(true);
                break;
            case 6:
                CloseAllStepObjects();
                CloseAllInteractables();
                stepObjectList[5].SetActive(true);
                sellBtn.interactable = true;
                break;
            case 7:
                CloseAllStepObjects();
                stepObjectList[6].SetActive(true);
                break;
            default:
                break;
        }
    }

    private void NextStep()
    {
        Step++;
        RunStep();
    }

    private void CloseAllStepObjects()
    {
        foreach (var item in stepObjectList)
        {
            item.SetActive(false);
        }
    }
    private void CloseAllInteractables()
    {
        startBtn.interactable= false;
        tradeBtn.interactable= false;
        sellBtn.interactable= false;
        changePageBtn.interactable= false;
    }

}
