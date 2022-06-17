using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    public float moveSpeed;
    public float scrollSpeed;
    public CinemachineVirtualCamera mCamera;

    private PlayerInputActions mPlayerInputActions;
    private InputAction mCameraMovementAction;
    private InputAction mCameraScrollAction;
    private float mFieldOfView;

    private void Awake()
    {
        mPlayerInputActions = new PlayerInputActions();
    }

    private void Start()
    {
        mFieldOfView = 60f;
    }

    private void OnEnable()
    {
        mCameraMovementAction = mPlayerInputActions.Player.CameraMovement;
        mCameraScrollAction = mPlayerInputActions.Player.CameraScroll;
        mCameraMovementAction.Enable();
        mCameraScrollAction.Enable();
    }

    private void OnDisable()
    {
        mCameraMovementAction.Disable();
        mCameraScrollAction.Disable();
    }

    private void Update()
    {
        //Scroll
        Vector2 cameraScroll = mCameraScrollAction.ReadValue<Vector2>();
        mFieldOfView -= cameraScroll.y * Time.deltaTime * scrollSpeed;
        mFieldOfView = Mathf.Clamp(mFieldOfView, 40, 100);
        mCamera.m_Lens.FieldOfView = mFieldOfView;

        // Movement
        Vector2 cameraMovement = mCameraMovementAction.ReadValue<Vector2>().normalized;
        transform.position += moveSpeed * Time.deltaTime 
            * new Vector3(cameraMovement.x, 0f, cameraMovement.y);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(transform.position, new Vector3(1f, 1f, 1f));
    }
}
