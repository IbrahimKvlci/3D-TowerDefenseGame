using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEnemySpawnerManager : IPlanetEnemySpawnerService
{
    public void SpawnRandomEnemy(Planet planet, Vector3 position)
    {
        GameObject.Instantiate(GetRandomEnemy(planet),position,Quaternion.identity);
    }

    private Enemy GetRandomEnemy(Planet planet)
    {
        int totalEnemyMultiplierCount=0;
        foreach (PlanetEnemy planetEnemy in planet.PlanetSO.planetEnemyList)
        {
            totalEnemyMultiplierCount += planetEnemy.CountMultiplier;
        }

        int randomValue = Random.Range(1, totalEnemyMultiplierCount+1);

        Enemy enemy = planet.PlanetSO.planetEnemyList[0].Enemy;

        foreach (PlanetEnemy planetEnemy in planet.PlanetSO.planetEnemyList)
        {
            if(planetEnemy.CountMultiplier >= randomValue)
            {
                enemy=planetEnemy.Enemy;
            }
        }

        return enemy;
    }
}
