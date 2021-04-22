using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMoviment : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 positionInFormation = new Vector3(0, 0, 0);

    public Vector3 PositionInFormation { get => positionInFormation; set => positionInFormation = value; }



    void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    public void Move(Vector3 hit)
    {
        agent.SetDestination(hit + positionInFormation);
    }
}