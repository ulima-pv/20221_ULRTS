using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance { private set; get; }

    private Dictionary<ResourceTypeSO, int> mResourceAmountsDictionary;
    private List<ResourceTypeSO> mResourceTypeList;

    private void Awake()
    {
        Instance = this;

        mResourceAmountsDictionary = new Dictionary<ResourceTypeSO, int>();

        mResourceTypeList = Resources.Load<ResourceTypeListSO>("ResourceList").list;
        foreach(var resourceType in mResourceTypeList)
        {
            mResourceAmountsDictionary.Add(resourceType, 0);
        }
    }

    public void AddResource(ResourceTypeSO resourceType)
    {
        mResourceAmountsDictionary[resourceType]++;

        string cad = "";
        foreach(var rType in mResourceTypeList)
        {
            cad += $"{rType.nameString}:{mResourceAmountsDictionary[rType]} ";
        }
        Debug.Log(cad);
    }
}
