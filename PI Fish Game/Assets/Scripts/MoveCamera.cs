using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public UnitManager manager;
    public float smoothSpeed = 1;

    void LateUpdate()
    {
        var centerCoords = manager.returnCenterCoordOfUnits();

        Vector3 desiredPosition = new Vector3(centerCoords.x - 15, transform.position.y, centerCoords.z - 15);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
    }     
}
