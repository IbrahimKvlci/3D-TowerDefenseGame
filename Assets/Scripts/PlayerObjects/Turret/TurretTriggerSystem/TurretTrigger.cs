using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TurretTrigger : MonoBehaviour
{
    [field:SerializeField] public LayerMask LayerMask { get; set; }

    public Enemy TriggeredEnemy { get; set; }

}
