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
        List<int> indexOfObjectList = new List<int>();

        float countMultiplier = timingMultiplier;

        foreach (PlanetEnemy planetEnemy in planet.PlanetSO.planetEnemyList)
        {
            float tempCountMultiplier = countMultiplier;
            tempCountMultiplier *= planetEnemy.CountMultiplier;
            if(tempCountMultiplier >= planetEnemy.MaxCountMultiplier)
                tempCountMultiplier = planetEnemy.MaxCountMultiplier;


            for (int i = 0; i < tempCountMultiplier; i++)
            {
                indexOfObjectList.Add(planet.PlanetSO.planetEnemyList.IndexOf(planetEnemy));
                Debug.Log( planetEnemy.Enemy.name);
            }
            //totalEnemyMultiplierCount += tempCountMultiplier;
        }

        int randomValue = Random.Range(0, indexOfObjectList.Count);

        Enemy enemy = planet.PlanetSO.planetEnemyList[0].Enemy;

        foreach (PlanetEnemy planetEnemy in planet.PlanetSO.planetEnemyList)
        {
            if (planet.PlanetSO.planetEnemyList.IndexOf(planetEnemy) == indexOfObjectList[randomValue])
                enemy = planetEnemy.Enemy;
        }

        return enemy;
    }
}
