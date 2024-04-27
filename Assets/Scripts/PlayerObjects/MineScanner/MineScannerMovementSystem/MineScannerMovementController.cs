using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MineScannerMovementController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private MineScanner mineScanner;
    [field: SerializeField] public List<MinePoint> MinePointPath;

    private int lastPointIndex;

    private IMineScannerMovementService _mineScannerMovementService;

    [Inject]
    public void Construct(IMineScannerMovementService mineScannerMovementService)
    {
        _mineScannerMovementService = mineScannerMovementService;
    }
    private void Start()
    {
        lastPointIndex = 0;
        
    }

    private void Update()
    {
        if(lastPointIndex < MinePointPath.Count)
        {
            _mineScannerMovementService.MoveToPoint(mineScanner, MinePointPath[lastPointIndex].transform,speed);
            if (_mineScannerMovementService.CheckMineScannerAtPoint(mineScanner, MinePointPath[lastPointIndex].transform))
                lastPointIndex++;
            Debug.Log(lastPointIndex);
        }
        
    }


}
