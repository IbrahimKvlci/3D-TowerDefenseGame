using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlanetEnemySpawnerService
{
    void SpawnRandomEnemy(Planet planet, Vector3 position,float timingMultiplier);
}
