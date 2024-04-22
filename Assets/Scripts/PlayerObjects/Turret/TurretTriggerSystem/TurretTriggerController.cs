using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TurretTriggerController : MonoBehaviour
{
    [SerializeField] private Turret turret;
    [SerializeField] private LayerMask layerMask;

    protected private ITurretTriggerService _turretTriggerService;

    public Enemy TriggeredEnemy { get; set; }

    [Inject]
    public void Construct(ITurretTriggerService turretTriggerService)
    {
        _turretTriggerService = turretTriggerService;
    }

    private void Update()
    {
        if (TriggeredEnemy == null)
        {
            TriggeredEnemy = _turretTriggerService.GetTriggeredEnemy(this, ((TurretSO)turret.PlayerObjectSO).range, layerMask);
        }
    }
}
