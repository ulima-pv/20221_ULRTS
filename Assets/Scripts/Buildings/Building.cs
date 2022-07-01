using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public BuildingTypeSO buildingType;

    private float mTimer = 0f;
    private float mTimerMax;
    private int mNearbyResources = 0;
    private bool mCanGenerate = false;

    private void Start()
    {
        float radius = 4f;
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        int nearbyResources = 0;
        foreach(var collider in colliders)
        {
            Resource resource = collider.GetComponent<Resource>();
            if (resource != null && resource.resourceType == buildingType.resourceType)
            {
                nearbyResources++;
            }
        }
        if (nearbyResources > 0) mCanGenerate = true;

        mNearbyResources = nearbyResources;
        ResourceGeneratorData generatorData = buildingType.resourceType.generatorData;
        mTimerMax = generatorData.timerMax - (mNearbyResources / generatorData.maxResources) + 0.5f;
    }
    private void Update()
    {
        if (mCanGenerate)
        {
            mTimer += Time.deltaTime;
            if (mTimer > mTimerMax)
            {
                // Generar un recurso
                GenerateResource();
                mTimer = 0f;
            }
        }
    }

    private void GenerateResource()
    {
        ResourceManager.Instance.AddResource(buildingType.resourceType);
    }

    public void SetActive(bool active)
    {
        transform.Find("selector").gameObject.SetActive(active);
    }

}
