using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackSpaceShipTrigger : MonoBehaviour
{
    [field: SerializeField] public LayerMask LayerMask { get; set; }

    public Enemy TriggeredEnemy { get; set; }
}
