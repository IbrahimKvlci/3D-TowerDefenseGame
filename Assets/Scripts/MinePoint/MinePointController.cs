using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MinePointController : MonoBehaviour
{
    [SerializeField] private float minMineCount, maxMineCount;


    [field: SerializeField] public List<MinePoint> PointList { get; set; }
    [field: SerializeField] public List<MinePoint> MinePointList { get; set; }

    private IMinePointService _minePointService;

    [Inject]
    public void Construct(IMinePointService minePointService)
    {
        _minePointService=minePointService;
    }

    private void Awake()
    {
        _minePointService.SetMinePointList(PointList, MinePointList, 10);
    }

    private void Start()
    {
        foreach (MinePoint minePoint in MinePointList)
        {
            _minePointService.SetRandomMineCount(minePoint, minMineCount, maxMineCount);
        }
    }
}
