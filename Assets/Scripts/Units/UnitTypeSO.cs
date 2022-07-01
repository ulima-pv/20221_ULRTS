using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UnitData
{
    public float maxHealth;
    public float damage;
    public float attackRange;
    public float currentHealth;
}

[CreateAssetMenu(menuName ="ScriptableObjects/UnitType")]
public class UnitTypeSO : ScriptableObject
{
    public string nameString;
    public float generationTime;
    public Sprite sprite;
    public Transform prefab;
    public UnitData data;
}
