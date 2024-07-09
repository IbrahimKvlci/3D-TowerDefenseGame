using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetEnemySpawnerManager : IPlanetEnemySpawnerService
{
    public void SpawnRandomEnemy(Planet planet, Vector3 position, float timingMultiplier)
    {
        GameObject.Instantiate(GetRandomEnemy(planet,timingMultiplier),position,Quaternion.identity);
    }

    private Enemy GetRandomEnemy(Planet planet,float timingMultiplier)
    {
        float totalEnemyMultiplierCount=0;
        float countMultiplier = timingMultiplier;

        foreach (PlanetEnemy planetEnemy in planet.PlanetSO.planetEnemyList)
        {
            float tempCountMultiplier = countMultiplier;
            tempCountMultiplier *= planetEnemy.CountMultiplier;
            if(tempCountMultiplier >= planetEnemy.MaxCountMultiplier)
                tempCountMultiplier = planetEnemy.MaxCountMultiplier;



            totalEnemyMultiplierCount += tempCountMultiplier;
        }

        float randomValue = Random.Range(1, totalEnemyMultiplierCount);

        Enemy enemy = planet.PlanetSO.planetEnemyList[0].Enemy;

        foreach (PlanetEnemy planetEnemy in planet.PlanetSO.planetEnemyList)
        {
            float tempCountMultiplier = countMultiplier;
            tempCountMultiplier *= planetEnemy.CountMultiplier;
            if (tempCountMultiplier >= planetEnemy.MaxCountMultiplier)
                tempCountMultiplier = planetEnemy.MaxCountMultiplier;

            if (tempCountMultiplier >= randomValue)
            {
                enemy=planetEnemy.Enemy;
            }

        }
        return enemy;
    }
}
