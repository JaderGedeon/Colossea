using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneType : MonoBehaviour
{
    public Zones zone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Unit") && zone != Zones.InnerCircle)
        {
            ZoneManager.instance.changeColor(zone);
            gameObject.GetComponent<ZoneType>().enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Unit") && zone == Zones.InnerCircle)
        {
            ZoneManager.instance.changeColor(Zones.ExternalCircle);
            gameObject.GetComponent<ZoneType>().enabled = false;
        }
    }
}
