using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarRocketLauncherTriggerController : MonoBehaviour
{
    [field:SerializeField] public LayerMask triggerLayerMask { get; set; }

    public Enemy TargetEnemy { get; set; }

    
}
