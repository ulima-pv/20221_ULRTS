using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingSelectorController : MonoBehaviour
{
    public float offset = 120f;
    private List<BuildingTypeSO> mBuildingsAvailable;

    private void Awake()
    {
        mBuildingsAvailable =  Resources.Load<BuildingTypeListSO>("BuildingList").list;
    }

    private void Start()
    {
        Transform mPrefabBuildingButton = Resources.Load<Transform>("BuildingSelectorUITemplate");

        int index = 0;

        foreach(BuildingTypeSO buildingType in mBuildingsAvailable)
        {
            Transform newButton = Instantiate(mPrefabBuildingButton, transform);
            newButton.Find("Sprite").GetComponent<Image>().sprite = buildingType.sprite;
            newButton.GetComponent<RectTransform>().anchoredPosition =
                new Vector2(index * offset , 0f);
            newButton.GetComponent<Button>().onClick.AddListener(() =>
            {
                BuildingManager.Instance.SetCurrentBuilding(buildingType);
            });
            index++;
        }
    }
}
