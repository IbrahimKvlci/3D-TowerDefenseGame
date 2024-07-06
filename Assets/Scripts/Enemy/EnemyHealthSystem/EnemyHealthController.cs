using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    [field: SerializeField] private GameObject enemyDamageVisual;
    [SerializeField] private Enemy enemy;

    private float damagedTimer;
    private bool isDamaged;

    private IEnemyHealthService _enemyHealthService;

    private void Awake()
    {
        _enemyHealthService=InGameIoC.Instance.EnemyHealthService;
    }

    private void Start()
    {
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
        enemyDamageVisual.SetActive(true);
    }

    public void HideEnemyDamageVisual()
    {
        enemyDamageVisual.SetActive(false);
    }
}
