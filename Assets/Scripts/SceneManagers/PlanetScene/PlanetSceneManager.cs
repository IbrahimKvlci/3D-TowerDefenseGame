using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlanetSceneManager : MonoBehaviour
{

    [Inject] private ObjectPlacement.Factory objectPlacementFactory;

    private void Start()
    {
        ObjectPlacement objectPlacement= objectPlacementFactory.Create();
        objectPlacement.transform.SetParent(Player.Instance.transform);

        Player.Instance.PlayerStateService.SwitchState(Player.Instance.PlayerIdleState);
    }
}
