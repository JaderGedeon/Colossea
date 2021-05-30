using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float smoothSpeed = 1;
    private Vector3 centerPoint = Vector3.zero;
    public float mapRadius;

    private void Start()
    {
        centerPoint.y = transform.position.y;
    }

    void LateUpdate()
    {
        var centerCoords = UnitManager.instance.returnCenterCoordOfUnits();

        Vector3 desiredPosition = new Vector3(centerCoords.x - 15, transform.position.y, centerCoords.z - 15);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;

        Camera.main.orthographicSize = 20 + (Vector3.Distance(transform.position, centerPoint) / mapRadius);
    }     
}
