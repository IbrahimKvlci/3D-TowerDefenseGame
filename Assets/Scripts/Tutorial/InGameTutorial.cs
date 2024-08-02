using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InGameTutorial : MonoBehaviour
{
    [SerializeField] private List<GameObject> stepObjectList;

    [SerializeField] private Button mineScannerBtn;
    [SerializeField] private Button mineBtn;
    [SerializeField] private Button turretBtn;

    private MineScanner mineScanner;

    public int Step { get; set; }

    private void Awake()
    {
        mineScannerBtn.onClick.AddListener(() =>
        {
            NextStep();
        });
        mineBtn.onClick.AddListener(() =>
        {
            NextStep();
        });
        turretBtn.onClick.AddListener(() =>
        {
            NextStep();
        });
    }

    private void Start()
    {
        ((PlayerHoldingObjectState)Player.Instance.PlayerHoldingObjectState).OnObjectPlace += InGameTutorial_OnObjectPlace;

        Step = 1;
        CloseAllStepObjects();
        RunStep();
    }

    private void InGameTutorial_OnObjectPlace(object sender, System.EventArgs e)
    {
        NextStep();

        mineScanner=FindAnyObjectByType<MineScanner>();
        ((MineScannerWaitingState)(mineScanner.MineScannerWaitingState)).OnMineScanned += InGameTutorial_OnMineScanned;
    }

    private void InGameTutorial_OnMineScanned(object sender, System.EventArgs e)
    {
        NextStep();
    }

    private void RunStep()
    {
        switch (Step)
        {
            case 1:
                CloseAllStepObjects();
                stepObjectList[0].SetActive(true);
                mineScannerBtn.interactable = true;
                break;
            case 2:
                mineScannerBtn.interactable= false;
                CloseAllStepObjects();
                stepObjectList[1].SetActive(true);

                break;
            case 3:
                CloseAllStepObjects();
                stepObjectList[2].SetActive(true);
                break;
            case 4:
                CloseAllStepObjects();
                stepObjectList[3].SetActive(true);
                mineBtn.interactable = true;
                break;
            case 5:
                mineBtn.interactable = false;
                CloseAllStepObjects();
                stepObjectList[4].SetActive(true);
                break;
            case 6:
                CloseAllStepObjects();
                stepObjectList[5].SetActive(true);
                turretBtn.interactable = true;
                break;
            case 7:
                turretBtn.interactable = false;
                CloseAllStepObjects();
                stepObjectList[6].SetActive(true);
                break;
            case 8:
                CloseAllStepObjects();
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
