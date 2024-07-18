using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer[] enemyMeshRenderer;
    [SerializeField] private Material enemyDamagedMaterial;


    [SerializeField] private Enemy enemy;

    private Material[] enemyMaterial;

    private float damagedTimer;
    private bool isDamaged;

    private IEnemyHealthService _enemyHealthService;

    private void Awake()
    {
        _enemyHealthService=InGameIoC.Instance.EnemyHealthService;
    }

    private void Start()
    {
        enemyMaterial = new Material[enemyMeshRenderer.Length];

        for (int i = 0; i < enemyMeshRenderer.Length; i++)
        {
            enemyMaterial[i] = enemyMeshRenderer[i].material;
        }

        //enemyMaterial = enemyMeshRenderer.material;
        isDamaged = false;
        damagedTimer = 0;
        _enemyHealthService.OnEnemyDamaged += enemyHealthService_OnEnemyDamaged;
    }

    private void Update()
    {
        if (isDamaged)
        {
            damagedTimer += Time.deltaTime;
            ShowEnemyDamageVisual();
            Debug.Log(2);

        }
        if (damagedTimer > 0.1f)
        {
            isDamaged = false;
            damagedTimer = 0;
            HideEnemyDamageVisual();
        }
    }

    private void enemyHealthService_OnEnemyDamaged(object sender, System.EventArgs e)
    {
        if (sender == enemy)
        {
            isDamaged = true;
            Debug.Log(1);
        }  
    }

    public void ShowEnemyDamageVisual()
    {
        foreach (var item in enemyMeshRenderer)
        {
            item.material = enemyDamagedMaterial;
        }

        //enemyMeshRenderer.material = enemyDamagedMaterial;
    }

    public void HideEnemyDamageVisual()
    {
        for (int i = 0; i < enemyMeshRenderer.Length; i++)
        {
            enemyMeshRenderer[i].material = enemyMaterial[i];
        }

        //enemyMeshRenderer.material = enemyMaterial;

    }
}
