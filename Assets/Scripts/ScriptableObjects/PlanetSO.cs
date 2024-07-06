using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu()]
public class PlanetSO : ScriptableObject
{
    public int price;
    public Sprite icon;
    public string title;
    public MineObject mineObject;
    public SceneLoader.Scene scene;
    public float enemySpawningRadius;
    public Vector3 planetCenter;
    public List<PlanetEnemy> planetEnemyList=new List<PlanetEnemy>();

}
