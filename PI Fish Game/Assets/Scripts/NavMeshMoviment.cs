using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMoviment : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 positionInFormation = new Vector3(0, 0, 0);
    private Vector3 positionToGo = Vector3.zero;
    private NavMeshPath navMeshPath;

    public Vector3 PositionInFormation { get => positionInFormation; set => positionInFormation = value; }

    void Awake()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        navMeshPath = new NavMeshPath();
    }

    public void Move(Vector3 hit)
    {
        var previewPosition = hit + positionInFormation;
        previewPosition.y = 0;

        if (CalculePath(previewPosition))
            positionToGo = previewPosition;
     
        agent.SetDestination(positionToGo);
    }

    bool CalculePath(Vector3 previewPosition)
    {
        agent.CalculatePath(previewPosition, navMeshPath);
        return navMeshPath.status != NavMeshPathStatus.PathInvalid;
    }
}