using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSceneManager : MonoBehaviour
{
    [SerializeField] private ObjectPlacement objectPlacement;

    private ObjectPlacement instantiatedObjectPlacement;

    private void Start()
    {
        instantiatedObjectPlacement = Instantiate(objectPlacement,Player.Instance.transform);

        Player.Instance.PlayerNewDay();
    }

    private void OnDestroy()
    {
        foreach (Transform child in Player.Instance.transform)
        {
            if (child == instantiatedObjectPlacement.transform)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
