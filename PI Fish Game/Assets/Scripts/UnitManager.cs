using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnitManager : MonoBehaviour
{

    public GameObject unitToSpawn; // Prefab of unit
    public Transform unitsContainer; // Father in hierarchy of units
    public int unitLimitCap; // Limit of units to spawn
    public float distanceBetweenUnits; // Distance between units

    public Formation unitFormation; // Class Formation

    // Moviment Variables

    private List<NavMeshMoviment> unitMovimentList = new List<NavMeshMoviment>(); // List of PlayerMoviment class in each unit

    private Camera cam; // Main Camera
    private RaycastHit hit; // Raycast
    private Ray ray; // Ray

    private void Start()
    {
        unitFormation = new Formation(distance: distanceBetweenUnits);
        cam = Camera.main;
        StartCoroutine(UnitsNeedToMove());
        UnitSpawn(new Vector3(hit.point.x, transform.position.y, hit.point.z));
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            UnitSpawn(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = unitMovimentList.Count; i < 100; i++)
            {
                UnitSpawn(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }
    }


    IEnumerator UnitsNeedToMove()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.2f);

            ray = cam.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit, 200, LayerMask.GetMask("Ground"));
            MoveUnits();
        }
    }

    public void MoveUnits()
    {
        float[] formationCenterPoint = unitFormation.CenterPoint;

        Vector3 posHit = new Vector3(hit.point.x - formationCenterPoint[0],
                                    0,
                                    hit.point.z - formationCenterPoint[1]);

        foreach (var unit in unitMovimentList)
        {
            unit.Move(posHit);
        }
    }

    public void UnitSpawn(Vector3 spawnPosition)
    {
        if (unitLimitCap > unitFormation.TotalUnits)
        {
            unitFormation.AddUnit();

            var formationPos = unitFormation.GetLastUnitCoordinate.GetXandZPosition;

            GameObject newUnit = Instantiate(unitToSpawn, spawnPosition, Quaternion.identity, unitsContainer);

            NavMeshMoviment newUnitMoviment = newUnit.GetComponent<NavMeshMoviment>();
            newUnitMoviment.PositionInFormation = new Vector3(formationPos[0], 0, formationPos[1]);
            unitMovimentList.Add(newUnitMoviment);
        }
    }

    public void RemoveUnit(GameObject unitToRemove)
    {
        NavMeshMoviment removedPlayerMoviment = unitToRemove.GetComponent<NavMeshMoviment>();

        if (unitFormation.TotalUnits == 1)
        {
            PlayerDeath();
            return;
        }
        for (int i = 0; i < unitMovimentList.Count; i++)
        {
            if (unitMovimentList[i] == removedPlayerMoviment)
            {
                if (i != unitMovimentList.Count - 1)
                {
                    unitMovimentList[unitMovimentList.Count - 1].PositionInFormation = unitMovimentList[i].PositionInFormation;
                    unitMovimentList.Insert(i, unitMovimentList[unitMovimentList.Count - 1]);
                    unitMovimentList.RemoveAt(i + 1);
                }
                unitMovimentList.RemoveAt(unitMovimentList.Count - 1);
                unitFormation.RemoveUnit();
                break;
            }
        }
    }
    private void PlayerDeath()
    {
        unitMovimentList.Clear();
        SceneManager.LoadScene(2);
        return;
    }

    public Vector3 returnCenterCoordOfUnits()
    {
        var totalX = 0f;
        var totalZ = 0f;

        foreach (var unit in unitMovimentList)
        {
            totalX += unit.transform.position.x;
            totalZ += unit.transform.position.z;
        }

        return new Vector3(totalX / unitMovimentList.Count, 0, totalZ / unitMovimentList.Count);
    }
}
