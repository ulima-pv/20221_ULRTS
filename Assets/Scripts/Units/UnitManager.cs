using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public enum Mode
    {
        Builder, Selection
    }

    public Transform cameraTarget;

    private UnitTypeSO currentUnitToSpawn = null;
    private List<Transform> mUnitsInGame= null;
    private List<Transform> mSelectedUnits = null;
    private Mode mMode;

    public static UnitManager Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
        mUnitsInGame = new List<Transform>();
        mSelectedUnits = new List<Transform>();
        mMode = Mode.Selection;
    }

    public void SetCurrentUnitToSpawn(UnitTypeSO unitType)
    {
        currentUnitToSpawn = unitType;
        // Instancear unidad
        Transform unit = Instantiate(unitType.prefab, 
            cameraTarget.position, Quaternion.identity);
        mUnitsInGame.Add( unit);
    }

    public void SetSelectedUnit(Transform unitPrefab)
    {
        unitPrefab.Find("selector").gameObject.SetActive(true);
        mSelectedUnits.Add(unitPrefab);
    }

    public void DeselectAllUnits()
    {
        foreach(var unit in mSelectedUnits)
        {
            unit.GetComponent<Unit>().SetActive(false);
        }
        mSelectedUnits.Clear();
    }

    public bool IsUnitsSelected()
    {
        return mSelectedUnits.Count > 0;
    }

    public void MoveUnits(Vector3 dest)
    {
        foreach (var unit in mSelectedUnits)
        {
            unit.GetComponent<Unit>().Move(dest);
        }
    }
}
