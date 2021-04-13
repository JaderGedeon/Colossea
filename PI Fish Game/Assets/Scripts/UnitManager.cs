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

    private Formation unitFormation; // Class Formation

    // Moviment Variables

    private List<NavMeshTest> unitMovimentList = new List<NavMeshTest>(); // List of PlayerMoviment class in each unit

    private Camera cam; // Main Camera
    private RaycastHit hit; // Raycast
    private Ray ray; // Ray

    private void Start()
    {
        unitFormation = new Formation(distance: distanceBetweenUnits);
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            UnitSpawn();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < 100; i++)
            {
                UnitSpawn();
            }
        }

        if (UnitsNeedToMove())
            MoveUnits();
    }

    public bool UnitsNeedToMove()
    {

        ray = cam.ScreenPointToRay(Input.mousePosition);

        return Physics.Raycast(ray, out hit, 200, LayerMask.GetMask("Ground"));
    }

    public void MoveUnits()
    {

        float[] formationCenterPoint = unitFormation.CenterPoint;

        Vector3 posHit = new Vector3(hit.point.x - formationCenterPoint[0],
                                    0,
                                    hit.point.z - formationCenterPoint[1]);

        for (int i = 0, end = unitMovimentList.Count; i < end; i++)
        {
            unitMovimentList[i].Move(posHit);
        }

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

            GameObject newUnit = Instantiate(unitToSpawn, vectorPosition, Quaternion.identity, unitsContainer);

            NavMeshTest newUnitMoviment = newUnit.GetComponent<NavMeshTest>();

            newUnitMoviment.PositionInFormation = vectorPosition;
            //newUnitMoviment.

            var formationCenterPoint = unitFormation.CenterPoint;
            
            /*
            newUnit.gameObject.transform.position = new Vector3(hit.point.x + vectorPosition.x - formationCenterPoint[0],
                                                                vectorPosition.y,
                                                                hit.point.z + vectorPosition.z - formationCenterPoint[1]);
            */
            newUnitMoviment.Start();

            unitMovimentList.Add(newUnitMoviment);
        }
        else
        {
            Debug.Log("Número máximo de unidades alcançadas");
        }
    }

    public void RemoveUnit(GameObject unitToRemove)
    {

        PlayerMoviment removedPlayerMoviment = unitToRemove.GetComponent<PlayerMoviment>();

        if (unitFormation.TotalUnits == 1)
        {
            unitMovimentList.Clear();
            SceneManager.LoadScene(2);       
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
}
