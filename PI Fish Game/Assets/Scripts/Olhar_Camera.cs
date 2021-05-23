using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olhar_Camera : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(2 * transform.position - (new Vector3(-70,60,-90) + transform.position));
    }
}
