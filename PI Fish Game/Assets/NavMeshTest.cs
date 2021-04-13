using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{

    public Camera cam;

    public NavMeshAgent agent;

    // Update is called once per frame
    void Update()
    {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit)) 
            {
                agent.SetDestination(hit.point);
            }
        
    }
}
