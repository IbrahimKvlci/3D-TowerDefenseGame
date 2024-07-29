using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu()]
public class PlanetSO : ScriptableObject
{
    public int price;
    public Material planetMaterial;
    public string title;
    public MineObject mineObject;
    public SceneLoader.Scene scene;
    public float enemySpawningRadius;
    public Vector3 planetCenter;
    public int startingHourToSpawnEnemy;
    public float speedToSpawnEnemy;
    public List<PlanetEnemy> planetEnemyList=new List<PlanetEnemy>();

}
