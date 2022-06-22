using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public void SetActive(bool active)
    {
        transform.Find("selector").gameObject.SetActive(active);
    }

}
