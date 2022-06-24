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
        mNearbyResources = nearbyResources;
        // TODO: Cambiar el timerMax en base a recursos cercanos
        mTimerMax = buildingType.resourceType.generatorData.timerMax;
    }
    private void Update()
    {
        mTimer += Time.deltaTime;
        if (mTimer > mTimerMax)
        {
            // Generar un recurso
            GenerateResource();
            mTimer = 0f;
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
