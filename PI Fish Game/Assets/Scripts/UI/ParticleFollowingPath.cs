using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleFollowingPath : MonoBehaviour
{

    public Transform[] pathPoints;

    public int speed = 10;
    int i = 0;

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, pathPoints[i].position, Time.deltaTime * speed);

        if (transform.position == pathPoints[i].position)
            i = i + 1 > pathPoints.Length - 1 ? 0 : i + 1;
    }
}
