using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;


public class BuildingManager : MonoBehaviour
{
    public enum Mode
    {
        Builder, Selection
    }

    public static BuildingManager Instance { private set; get; }

    private PlayerInputActions mPlayerInputActions;
    private InputAction mMouseMovementAction;
    private Camera mCamera;
    private Ray mRay;
    private RaycastHit mHit;
    private List<BuildingTypeSO> mBuildingTypeList;
    private int mCurrentBuildingIndex = 0;
    private BuildingTypeSO mCurrentBuilding = null;
    private bool mMouseClicked = false;
    private bool mMouseRightClicked = false;
    private Mode mMode;

    private List<Building> mSelectedBuildings;

    private void Awake()
    {
        Instance = this;

        mPlayerInputActions = new PlayerInputActions();

        mBuildingTypeList = Resources.Load<BuildingTypeListSO>("BuildingList").list;
        mSelectedBuildings = new List<Building>();
        mMode = Mode.Selection;
    }

    private void Start()
    {
        mCamera = Camera.main;
    }

    private void Update()
    {
        if (mMouseClicked)
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
                    if (mMode != Mode.Selection)
                    {
                        //Modo Construccion
                        // Instanciar el primer elemento de nuestro buildingTypeList
                        if (CanSpawnBuilding(mHit.point, mCurrentBuilding))
                        {
                            Instantiate(mCurrentBuilding.prefab,
                                mHit.point, Quaternion.identity);
                        }
                    }else
                    {
                        // Modo seleccion

                        Building building = mHit.collider.GetComponent<Building>();
                        if (building != null)
                        {
                            building.SetActive(true);
                            mSelectedBuildings.Add(building);
                        }
                        else
                        {
                            Unit unit = mHit.collider.GetComponent<Unit>();

                            if (unit != null)
                            {
                                // Se selecciono una unidad
                                UnitManager.Instance.SetSelectedUnit(mHit.collider.transform);
                            }else
                            {
                                // Deseleccionar todos los buildings
                                foreach (var selectedBuilding in mSelectedBuildings)
                                {
                                    selectedBuilding.SetActive(false);
                                }
                                mSelectedBuildings.Clear();

                                UnitManager.Instance.DeselectAllUnits();

                            }

                        }
                    }
                }
                
            }
            mMouseClicked = false;
        }

        if (mMouseRightClicked && UnitManager.Instance.IsUnitsSelected())
        {
            // Mover
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
                    UnitManager.Instance.MoveUnits(mHit.point);
                }
            }
            mMouseRightClicked = false;
        }
    }

    private void OnEnable()
    {
        mMouseMovementAction = mPlayerInputActions.Player.MouseMovement;
        mPlayerInputActions.Player.MouseSelect.performed += OnMouseSelected;
        mPlayerInputActions.Player.TabPressed.performed += OnTabPressed;
        mPlayerInputActions.Player.EscPressed.performed += OnEscPressed;
        mPlayerInputActions.Player.MouseDirection.performed += OnMouseRightClick;
        mPlayerInputActions.Enable();
    }

    private void OnEscPressed(InputAction.CallbackContext obj)
    {
        mCurrentBuilding = null;
        mMode = Mode.Selection;
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
        mMouseClicked = true;
    }

    private void OnMouseRightClick(InputAction.CallbackContext obj)
    {
        mMouseRightClicked = true;
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

    public void SetCurrentBuilding(BuildingTypeSO buildingType)
    {
        mCurrentBuilding = buildingType;
        mMode = Mode.Builder;
    }

    private bool CanSpawnBuilding(Vector3 position, BuildingTypeSO building)
    {
        BoxCollider buildingCollider = building.prefab.GetComponent<BoxCollider>();
        Collider[] colliders = Physics.OverlapBox(
            position,
            new Vector3(
                buildingCollider.size.x / 2f,
                buildingCollider.size.y / 2f,
                buildingCollider.size.z / 2f
            )
        );

        // TODO: Mejorar con layerMask
        foreach(var collider in colliders)
        {
            if (collider.GetComponent<Building>() != null)
            {
                return false;
            }
        }
        return true;
    }
}
