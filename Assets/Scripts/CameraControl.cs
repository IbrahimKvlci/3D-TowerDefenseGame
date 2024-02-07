using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float camMovementSpeed=1f;
    [SerializeField] private float zoomSpeed=5f;

    IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    private void Start()
    {
        _inputService.OnMouseScrollScrolled += inputService_OnMouseScrollScrolled;
    }

    private void inputService_OnMouseScrollScrolled(object sender, System.EventArgs e)
    {
        Vector3 zoomVector = new Vector3(0, 0, _inputService.GetMouseScrollValue());

        HandleZoom(zoomVector,zoomSpeed);
    }

    private void Update()
    {
        HandleCameraMovement();

    }

    private void HandleCameraMovement()
    {
        Vector3 mousePos = new Vector3(_inputService.GetMousePositionInCamera().x, 0, _inputService.GetMousePositionInCamera().y);

        float mouseMaxDistance = .95f;
        if (mousePos.magnitude>mouseMaxDistance)
        {
            //Mouse is next to camera last points!
            transform.position += mousePos*Time.deltaTime*camMovementSpeed;

        }
    }

    private void HandleZoom(Vector3 zoomVector,float speed)
    {
        Vector3 vector = zoomVector * Time.deltaTime * speed;
        transform.Translate(vector);
    }
}
