using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MineScanner : MonoBehaviour
{
    public MinePoint MinePoint {  get; set; }

    [SerializeField] private MinePointController minePointController;

    private IMineScannerService _mineScannerService;

    [Inject]
    public void Construct(IMineScannerService mineScannerService)
    {
        _mineScannerService = mineScannerService;
    }

    private void Start()
    {
        _mineScannerService.SetMinePointToScanner(this, minePointController.MinePointList);
    }
}
