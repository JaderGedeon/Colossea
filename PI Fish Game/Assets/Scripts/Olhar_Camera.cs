using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Olhar_Camera : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
    }
}
