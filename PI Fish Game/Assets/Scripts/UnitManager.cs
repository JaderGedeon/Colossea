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
    private bool listSplitter = false;

    private Camera cam; // Main Camera
    private RaycastHit hit; // Raycast
    private Ray ray; // Ray


    private void Start()
    {
        unitFormation = new Formation(distance: distanceBetweenUnits);
        cam = Camera.main;
        StartCoroutine(UnitsNeedToMove());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UnitSpawn();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = unitMovimentList.Count; i < 100; i++)
            {
                UnitSpawn();
            }
        }
    }

    IEnumerator UnitsNeedToMove() {
        while (true) {
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
        
        /*
        int startIndex = 0;
        int endIndex = unitMovimentList.Count;

        
        if (unitMovimentList.Count > 50)
        {
            if (listSplitter)
                startIndex = 50;
            else
                endIndex = 50;

            listSplitter = !listSplitter;
        }
        

        for (int i = startIndex, end = endIndex; i < end; i++)
        {
            unitMovimentList[i].Move(posHit);
        }
        */
    }

    public void UnitSpawn()
    {
        if (unitLimitCap > unitFormation.TotalUnits)
        {
            unitFormation.AddUnit();

            var lastUnitCoordinate = unitFormation.GetLastUnitCoordinate.GetXandZPosition;

            Vector3 vectorPosition = new Vector3(lastUnitCoordinate[0],
                                                transform.position.y,
                                                lastUnitCoordinate[1]);

            Vector3 spawnPosition = new Vector3(hit.point.x + vectorPosition.x - unitFormation.CenterPoint[0],
                                                vectorPosition.y,
                                                hit.point.z + vectorPosition.z - unitFormation.CenterPoint[1]);

            GameObject newUnit = Instantiate(unitToSpawn, spawnPosition, Quaternion.identity, unitsContainer);

            NavMeshMoviment newUnitMoviment = newUnit.GetComponent<NavMeshMoviment>();
            newUnitMoviment.PositionInFormation = vectorPosition;
            unitMovimentList.Add(newUnitMoviment);
        }
        else
        {
            Debug.Log("Número máximo de unidades alcançadas");
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
        var centerPoint = unitFormation.CenterPoint;

        var posUnit = unitMovimentList.Count != 0 
            ? unitMovimentList[0].gameObject.transform.position 
            : Vector3.zero;

        return new Vector3(posUnit.x + centerPoint[0], 0, posUnit.z + centerPoint[1]);
    }
}
