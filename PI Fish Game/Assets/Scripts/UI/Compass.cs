using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject map;
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
            Vector3 dir = map.transform.position - UnitManager.instance.returnCenterCoordOfUnits();
            dir = map.transform.InverseTransformDirection(dir);
            float angle = Mathf.Atan2(dir.z, dir.x) * Mathf.Rad2Deg;

        try
        {
            rectTransform.localRotation = Quaternion.Euler(0, 0, angle - 45);
        }
        catch (System.Exception)
        {

            throw;
        }

           
        
    }
}
