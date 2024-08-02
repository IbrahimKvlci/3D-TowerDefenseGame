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

    public static int Step { get; set; }

    

    private void Awake()
    {
        startBtn.onClick.AddListener(() =>
        {
            NextStep();
            startBtn.interactable = false;
        });
        travelBtn.onClick.AddListener(() =>
        {
            travelBtn.interactable = false;

        });
        sellBtn.onClick.AddListener(() =>
        {
            NextStep();
            startBtn.interactable = false;

        });
        changePageBtn.onClick.AddListener(() =>
        {
            NextStep();
            startBtn.interactable = false;

        });
        tradeBtn.onClick.AddListener(() =>
        {
            NextStep();
            startBtn.interactable = false;

        });
        exitTutorialBtn.onClick.AddListener(() =>
        {
            Player.Instance.PlayerFirstPlay = false;
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
                stepObjectList[0].SetActive(true);
                break;
            case 2:
                CloseAllStepObjects();
                stepObjectList[1].SetActive(true);
                break;
            case 3:
                CloseAllStepObjects();
                stepObjectList[2].SetActive(true);
                Debug.Log("worked");
                break;
            case 4:
                CloseAllStepObjects();
                stepObjectList[3].SetActive(true);
                break;
            case 5:
                CloseAllStepObjects();
                stepObjectList[4].SetActive(true);
                break;
            case 6:
                CloseAllStepObjects();
                stepObjectList[5].SetActive(true);
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

}
