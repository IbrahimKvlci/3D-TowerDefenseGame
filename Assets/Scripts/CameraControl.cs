using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float camMovementSpeed=1f;

    private void Update()
    {
        HandleCameraMovement();
    }

    private void HandleCameraMovement()
    {
        Vector3 mousePos = new Vector3(InputManager.Instance.GetMousePositionInCamera().x, 0, InputManager.Instance.GetMousePositionInCamera().y);

        float mouseMaxDistance = .95f;
        if (mousePos.magnitude>mouseMaxDistance)
        {
            //Mouse is next to camera last points!
            transform.position += mousePos*Time.deltaTime*camMovementSpeed;

        }
        



    }
}
