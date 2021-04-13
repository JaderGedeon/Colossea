using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshTest : MonoBehaviour
{

    private Camera cam;
    private NavMeshAgent agent;

    private Vector3 positionInFormation = new Vector3(0, 0, 0);

    public Vector3 PositionInFormation { get => positionInFormation; set => positionInFormation = value; }

    public void Start()
    {
        cam = Camera.main;
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 hit)
    {
        agent.SetDestination(hit + positionInFormation);
    }
}