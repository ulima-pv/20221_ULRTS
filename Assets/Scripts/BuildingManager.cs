using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class BuildingManager : MonoBehaviour
{
    private PlayerInputActions mPlayerInputActions;
    private InputAction mMouseMovementAction;
    private Camera mCamera;
    private Ray mRay;
    private RaycastHit mHit;
    private List<BuildingTypeSO> mBuildingTypeList;
    private int mCurrentBuildingIndex = 0;

    private void Awake()
    {
        mPlayerInputActions = new PlayerInputActions();

        mBuildingTypeList = Resources.Load<BuildingTypeListSO>("BuildingList").list;

    }

    private void Start()
    {
        mCamera = Camera.main;
    }

    private void OnEnable()
    {
        mMouseMovementAction = mPlayerInputActions.Player.MouseMovement;
        mPlayerInputActions.Player.MouseSelect.performed += OnMouseSelected;
        mPlayerInputActions.Player.TabPressed.performed += OnTabPressed;
        mPlayerInputActions.Enable();
    }

    private void OnTabPressed(InputAction.CallbackContext obj)
    {
        mCurrentBuildingIndex++;
        if (mCurrentBuildingIndex >= mBuildingTypeList.Count)
        {
            mCurrentBuildingIndex = 0;
        }
    }

    private void OnMouseSelected(InputAction.CallbackContext obj)
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            Vector2 mousePos = mMouseMovementAction.ReadValue<Vector2>();
            // Lanzar el Raycast
            mRay = mCamera.ScreenPointToRay(mousePos);
            if (Physics.Raycast(
                mRay,
                out mHit,
                1000f
                ))
            {
                // Instanciar el primer elemento de nuestro buildingTypeList
                Instantiate(mBuildingTypeList[mCurrentBuildingIndex].prefab, 
                    mHit.point, Quaternion.identity);
            }
        }
        
    }

    private void OnDisable()
    {
        mPlayerInputActions.Disable();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(mHit.point, 1f);
    }
}
