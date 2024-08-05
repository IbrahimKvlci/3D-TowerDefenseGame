using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherRocketVisualController : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private RadarRocketLauncher radarRocketLauncher;

    private GameObject rocket;
    private Vector3 spawnPos;

    private float movementTimer;

    private void Start()
    {
        ((RadarRocketLauncherRocketCreatingState)radarRocketLauncher.RadarRocketLauncherRocketCreatingState).OnRocketCreated += RadarRocketLauncherRocketVisualController_OnRocketCreated;
        ((RadarRocketLauncherRocketArrivingState)radarRocketLauncher.RadarRocketLauncherRocketArrivingState).OnAttacked += RadarRocketLauncherRocketVisualController_OnAttacked;

        movementTimer = 0;
    }

    private void RadarRocketLauncherRocketVisualController_OnAttacked(object sender, System.EventArgs e)
    {
        DestroyRocket();
    }

    private void RadarRocketLauncherRocketVisualController_OnRocketCreated(object sender, System.EventArgs e)
    {
        spawnPos = radarRocketLauncher.RadarRocketLauncherTriggerController.TargetEnemy.transform.position;
        spawnPos.y = 100;
        spawnPos += new Vector3(50, 0, 50);
        rocket = Instantiate(rocketPrefab, spawnPos, Quaternion.identity,radarRocketLauncher.transform);
        rocket.transform.forward = radarRocketLauncher.RadarRocketLauncherTriggerController.TargetEnemy.transform.position;

    }

    private void Update()
    {
        HandleRocketMovement();
    }

    private void DestroyRocket()
    {
        Destroy(rocket.gameObject);
        rocket = null;
    }

    private void HandleRocketMovement()
    {
        if (rocket != null)
        {
            movementTimer += Time.deltaTime;
            float percentageComplete = movementTimer / ((RadarRocketLauncherSO)radarRocketLauncher.PlayerObjectSO).rocketArrivalTime;

            rocket.transform.position = Vector3.Lerp(spawnPos, radarRocketLauncher.RadarRocketLauncherTriggerController.TargetEnemy.transform.position, percentageComplete);

            rocket.transform.LookAt(radarRocketLauncher.RadarRocketLauncherTriggerController.TargetEnemy.transform.position);
        }

        else
        {
            movementTimer = 0;
        }
    }
        
    
}
