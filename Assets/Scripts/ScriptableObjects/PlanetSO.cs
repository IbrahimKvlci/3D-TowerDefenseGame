using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.SearchService;
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
}
