using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSceneManager : MonoBehaviour
{
    [SerializeField] private ObjectPlacement objectPlacement;

    private void Start()
    {
        Instantiate(objectPlacement,Player.Instance.transform);

        Player.Instance.PlayerStateService.SwitchState(Player.Instance.PlayerIdleState);
    }
}
