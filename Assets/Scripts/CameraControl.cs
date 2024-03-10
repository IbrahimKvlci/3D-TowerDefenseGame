using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private float camMovementSpeed=1f;
    [SerializeField] private float zoomSpeed=5f;
    [SerializeField] private int maxZoom,minZoom;

    private bool cameraLocked;

    IInputService _inputService;

    [Inject]
    public void Construct(IInputService inputService)
    {
        _inputService = inputService;
    }

    private void Start()
    {
        _inputService.OnMouseScrollScrolled += inputService_OnMouseScrollScrolled;
        _inputService.OnLockKeyDown += inputService_OnLockKeyDown;

        cameraLocked= false;
    }

    private void inputService_OnLockKeyDown(object sender, System.EventArgs e)
    {
        cameraLocked=!cameraLocked;
    }

    private void inputService_OnMouseScrollScrolled(object sender, System.EventArgs e)
    {
        Vector3 zoomVector = new Vector3(0, 0, _inputService.GetMouseScrollValue());

        HandleZoom(zoomVector,zoomSpeed);
    }

    private void Update()
    {
        if(!cameraLocked)
        {
            HandleCameraMovement();
        }
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

    private void HandleZoom(Vector3 zoomVector, float speed)
    {
        if (GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize+ zoomVector.z * speed * -1 >= maxZoom)
        {
            GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = maxZoom;
        } else if (GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize+ zoomVector.z * speed * -1 <= minZoom)
        {
            GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize = minZoom;
        }
        else
        {
            GetComponent<CinemachineVirtualCamera>().m_Lens.OrthographicSize += zoomVector.z * speed * -1;

        }
    }
}
