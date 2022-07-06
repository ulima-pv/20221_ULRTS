using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitSelectorController : MonoBehaviour
{
    private float offset = 120f;

    private List<UnitTypeSO> mUnitsAvailable;

    private void Awake()
    {
        mUnitsAvailable = Resources.Load<UnitTypeListSO>("UnitsList").list;
    }

    private void Start()
    {
        Transform mPrefabUnitButton = Resources.Load<Transform>("UnitSelectorUITemplate");

        int index = 0;
        foreach(var unitType in mUnitsAvailable)
        {
            Transform newButton = Instantiate(mPrefabUnitButton, transform);
            newButton.Find("Sprite").GetComponent<Image>().sprite = unitType.sprite;
            newButton.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(index * offset, 0f);
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                //BuildingManager.Instance.SetCurrentBuilding(buildingType);
                Debug.Log("Se debe construir unidad");
                UnitManager.Instance.SetCurrentUnitToSpawn(unitType);
            });
            index++;
        }
    }
}
