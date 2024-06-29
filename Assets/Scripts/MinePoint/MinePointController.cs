using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinePointController : MonoBehaviour
{
    [SerializeField] private float minMineCount, maxMineCount;


    [field: SerializeField] public List<MinePoint> PointList { get; set; }
    [field: SerializeField] public List<MinePoint> MinePointList { get; set; }

    private IMinePointService _minePointService;

    public static MinePointController Instance { get; set; }


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);
        }
        Instance= this;

        _minePointService = InGameIoC.Instance.MinePointService;

        _minePointService.SetMinePointList(PointList, MinePointList, 1);
    }

    private void Start()
    {
        foreach (MinePoint minePoint in MinePointList)
        {
            _minePointService.SetRandomMineCount(minePoint, minMineCount, maxMineCount);
        }
    }
}
