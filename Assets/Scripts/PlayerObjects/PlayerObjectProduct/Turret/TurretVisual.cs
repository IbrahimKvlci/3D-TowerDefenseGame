using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVisual : MonoBehaviour
{
    [field: SerializeField] private GameObject turretHead;
    [SerializeField] private GameObject muzzleFlashParticle;
    [SerializeField] private TurretTrigger turretTrigger;
    [SerializeField] private Turret turret;

    private void Start()
    {
        ((TurretFireState)turret.TurretFireState).OnTurretAttacked += TurretVisual_OnTurretAttacked;
        ((TurretFireState)turret.TurretFireState).OnTurretAttackedStoped += TurretVisual_OnTurretAttackedStoped;

        HideMuzzleFlash();
    }

    private void TurretVisual_OnTurretAttackedStoped(object sender, System.EventArgs e)
    {
        HideMuzzleFlash();
    }

    private void TurretVisual_OnTurretAttacked(object sender, System.EventArgs e)
    {
        ShowMuzzleFlash();
    }

    private void Update()
    {
        if (turretTrigger.TriggeredEnemy != null)
        {
            Vector3 enemyDir=turretTrigger.TriggeredEnemy.transform.position- turretHead.transform.position;
            enemyDir.y = 0;
            enemyDir.Normalize();

            turretHead.transform.forward = Vector3.Slerp(turretHead.transform.forward, enemyDir, 0.5f);
        }
    }

    public void ShowMuzzleFlash()
    {
    muzzleFlashParticle.SetActive(true);

    }

    public void HideMuzzleFlash()
    {

    muzzleFlashParticle.SetActive(false); 
    }


}
