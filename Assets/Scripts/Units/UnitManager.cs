using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    public Transform cameraTarget;

    private UnitTypeSO currentUnitToSpawn = null;
    private List<Transform> mUnitsInGame= null;

    public static UnitManager Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
        mUnitsInGame = new List<Transform>();
    }

    public void SetCurrentUnitToSpawn(UnitTypeSO unitType)
    {
        currentUnitToSpawn = unitType;
        // Instancear unidad
        Transform unit = Instantiate(unitType.prefab, 
            cameraTarget.position, Quaternion.identity);
        mUnitsInGame.Add( unit);
    }
}
