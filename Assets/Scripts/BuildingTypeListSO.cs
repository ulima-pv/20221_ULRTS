using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="ScriptableObjects/BuildingTypeList")]
public class BuildingTypeListSO : ScriptableObject
{
    public string nameString;
    public List<BuildingTypeSO> list;
}
