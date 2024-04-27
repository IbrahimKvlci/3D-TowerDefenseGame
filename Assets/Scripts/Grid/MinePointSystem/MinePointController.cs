using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MinePointController : MonoBehaviour
{
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
}
